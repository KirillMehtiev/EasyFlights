import ko = require("knockout");

import { DataService } from "../DataService";
import { ISignUpModel } from "./ISignUpModel";
import { ISignInModel } from "./ISignInModel";

export class AuthService {
    private dataService: DataService;

    public static current: AuthService = new AuthService();

    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor() {
        this.dataService = new DataService();

        this.isCurrentUserSignedIn = ko.observable<boolean>();
        this.trySignInCurrentUser();
    }

    public signUp(model: ISignUpModel) {
        return this.dataService
            .post("/api/account/signup", model)
            .then((response => {
                this.isCurrentUserSignedIn(true);
                window.location.href = "#";
            }));
    }

    public signIn(model: ISignInModel) {
        return this.dataService
            .post("/api/account/signin", model)
            .then((response => {
                this.isCurrentUserSignedIn(true);
                window.location.href = "#";
            }));
    }

    public facebookLogin() {
        return this.dataService
            .get("api/account/externallogin?provider=Facebook")
            .then((response => {
                this.isCurrentUserSignedIn(true);
                window.location.href = "#";
            }));
    }

    public signOut() {
        return this.dataService
            .post("/api/account/signout")
            .then((response => {
                this.isCurrentUserSignedIn(false);
                window.location.href = "#sign-in";
            }));
    }

    private trySignInCurrentUser() {
        this.dataService
            .get("/api/account/IsAuthenticated")
            //        .then((response) => {
            //            console.log("response: " + response);
            //            this.isCurrentUserSignedIn(true);
            //        })
            //        .fail((error) => {
            //            console.log("er: ", error);
            //            this.isCurrentUserSignedIn(false);
            //        });
            .always(response => {
                this.isCurrentUserSignedIn(response.statusCode == 200);
            });
    }
    
}