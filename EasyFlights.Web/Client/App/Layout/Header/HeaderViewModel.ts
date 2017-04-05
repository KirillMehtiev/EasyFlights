import { IHeaderOptions } from "./IHeaderOptions"
import {AuthService } from "../../Common/Services/Auth/authService";

class HeaderViewModel {
    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor(options: IHeaderOptions) {
        this.isCurrentUserSignedIn = options.isCurrentUserSignedIn;

        console.log(this.isCurrentUserSignedIn);
        console.log(this.isCurrentUserSignedIn());
    }

    public signOut() {
        AuthService.current.signOut();
    }
}

export = HeaderViewModel;