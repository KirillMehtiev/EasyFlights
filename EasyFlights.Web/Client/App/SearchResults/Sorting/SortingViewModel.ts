class SortingViewModel {
    public sortingOption: KnockoutObservable<string>;
    constructor() {
        let sorting: string = "by-price";

        this.sortingOption = ko.observable(sorting);
    }
}
export = SortingViewModel;