class OrderFullInfoModel {

    public departureCity: KnockoutObservable<string>;
    public destinationCity: KnockoutObservable<string>;
    public cost: KnockoutObservable<number>;
    public duration: KnockoutObservable<string>;
    public departureDate: KnockoutObservable<string>;

    public tickets: KnockoutObservableArray<any>;

    constructor() {
        this.departureCity = ko.observable("");
        this.destinationCity = ko.observable("");
        this.cost = ko.observable<number>();
        this.duration = ko.observable("");
        this.departureDate = ko.observable("");
    }
}

export = OrderFullInfoModel;