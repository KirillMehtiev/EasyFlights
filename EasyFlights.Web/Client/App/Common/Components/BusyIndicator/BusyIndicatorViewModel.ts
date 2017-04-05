import { IBusyIndicatorOptions } from "./IBusyIndicatorOptions";

class BusyIndicatorViewModel {

    public isVisible: KnockoutObservable<boolean>;

    constructor(options: IBusyIndicatorOptions) {
        this.isVisible = options.isLoading;
    }
}

export = BusyIndicatorViewModel;