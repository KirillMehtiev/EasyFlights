"use strict";
var SearchHeaderViewModel = (function () {
    function SearchHeaderViewModel() {
        var viewModel = {
            destinationCity: "Kharkiv",
            arrivalCity: "Paris",
            datetime: "14/04/2017"
        };
        this.destinationCity = ko.observable(viewModel.destinationCity);
        this.arrivalCity = ko.observable(viewModel.arrivalCity);
        this.datetime = ko.observable(viewModel.datetime);
    }
    return SearchHeaderViewModel;
}());
module.exports = SearchHeaderViewModel;
//# sourceMappingURL=SearchHeaderViewModel.js.map