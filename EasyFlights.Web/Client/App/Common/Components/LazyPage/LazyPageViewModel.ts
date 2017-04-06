class LazyPageViewModel {
    public departurePlace: string;
    public id: string;
    public guard: any;
    public params: string[];
    public pageVisible: KnockoutObservable<boolean>;

    constructor(params) {
        this.id = params.id;
        this.guard = params.guard;
        this.params = params.params;
        this.pageVisible = ko.observable(false);
    }

    public onShow(callback, page): void {
        callback({});
    }

}

export = LazyPageViewModel;