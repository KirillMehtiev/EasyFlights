import { AuthService } from "../Common/Services/Auth/authService"

class LayoutViewModel {
    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor() {
        this.isCurrentUserSignedIn = AuthService.current.isCurrentUserSignedIn;
        // TODO: fix
        // this.guardPage.bind(this);
    }

    private guardPage = (page, route, callback) => {

        window.setTimeout(() => {
            if (this.isCurrentUserSignedIn()) {
                callback();
            }
            else {
                window.location.href = "#sign-in";
            }
        });


    }
}

export = LayoutViewModel