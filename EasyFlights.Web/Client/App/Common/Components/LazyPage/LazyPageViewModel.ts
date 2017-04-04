class LazyPageViewModel {
    public departurePlace: string;
    public id: string;
    public params: string[];
    public pageVisible: KnockoutObservable<boolean>;

    constructor(params) {
        console.log(params);
        this.id = params.id;
        this.params = params.params;
        this.pageVisible = ko.observable(false);
    }

    public onShow(callback, page): void {
        callback({});
    }

}

export = LazyPageViewModel;