import ko = require("knockout");
import $ = require("jquery");
require("jqueryCookie");

import { DataService } from "../DataService";
import { ISignUpModel } from "./ISignUpModel";

export class AuthService {
    private static authCookieName: string = ";alsdfj;dlasfj";

    private dataService: DataService;

    public static current: AuthService = new AuthService();

    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor() {
        this.dataService = new DataService();
        this.isCurrentUserSignedIn = ko.observable(<boolean>$.cookie(AuthService.authCookieName));
    }

    public SignUp(model: ISignUpModel) {
        return this.dataService
                    .post("/api/account/register", model)
                    .then((response => {

                        // TODO: do something, maybe, set cookie

                        return false;
                    }));
    }

    public SignIn() {

        this.isCurrentUserSignedIn(true);
    }

    public SignOut() {

        this.isCurrentUserSignedIn(false);
    }
}