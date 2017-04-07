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

    public externalLogin(provider) {
        var newWindow=window.open("api/account/externallogin?provider=".concat(provider),
            provider.concat("Login"),
            "width=800, height=600,resizable=no,scrollbars=no,status=no");    
        newWindow.onemptied=()=>newWindow.close();  
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
            .then((response) => {
                console.log("response: " + response);
                this.isCurrentUserSignedIn(true);
            })
            .fail((error) => {
                console.log("er: ", error);
                this.isCurrentUserSignedIn(false);
            });
    }
    
}