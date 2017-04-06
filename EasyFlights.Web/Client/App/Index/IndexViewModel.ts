class IndexViewModel {
    seatNumber: KnockoutObservable<number>;

    constructor() {
        this.seatNumber = ko.observable<number>();
    }
}

export = IndexViewModel;