import { IHeaderOptions } from "./IHeaderOptions"

class HeaderViewModel {
    public isCurrentUserSignedIn: KnockoutObservable<boolean>;

    constructor(options: IHeaderOptions) {
        this.isCurrentUserSignedIn = options.isCurrentUserSignedIn;
    }
}

export = HeaderViewModel;