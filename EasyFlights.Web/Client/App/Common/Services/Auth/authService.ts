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

        let cookie = $.cookie(AuthService.authCookieName) || false;

        console.log(cookie);

        this.isCurrentUserSignedIn = ko.observable(<boolean>cookie);
    }

    public signUp(model: ISignUpModel) {
        return this.dataService
                    .post("/api/account/signup", model)
                    .then((response => {

                        console.log("auth reg");
                        console.log(response);

                        // TODO: do something, maybe, set cookie

                    }));
    }

    public signIn() {

        this.isCurrentUserSignedIn(true);
    }

    public signOut() {

        this.isCurrentUserSignedIn(false);
    }
}