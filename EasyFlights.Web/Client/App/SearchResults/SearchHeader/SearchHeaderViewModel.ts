class SearchHeaderViewModel {

    public destinationCity: KnockoutObservable<string>;
    public arrivalCity: KnockoutObservable<string>;
    public datetime: KnockoutObservable<string>

    constructor() {
        var viewModel = {
            destinationCity: "Kharkiv",
            arrivalCity: "Paris",
            datetime: "14/04/2017"

        };
        this.destinationCity = ko.observable(viewModel.destinationCity);
        this.arrivalCity = ko.observable(viewModel.arrivalCity);
        this.datetime = ko.observable(viewModel.datetime);
    }
}


export = SearchHeaderViewModel;