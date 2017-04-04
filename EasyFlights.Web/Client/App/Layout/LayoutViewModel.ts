import { AuthService } from "../Common/Services/Auth/authService"

class LayoutViewModel {
    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor() {
        this.isCurrentUserSignedIn = AuthService.current.isCurrentUserSignedIn;

        // TODO: fix
        // this.guardPage.bind(this);
    }

    private guardPage = (page, route, callback) => {
        if (this.isCurrentUserSignedIn()) {
            callback();
        }
    }
}

export = LayoutViewModel