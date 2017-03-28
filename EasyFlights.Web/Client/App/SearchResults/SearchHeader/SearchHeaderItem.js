"use strict";
exports.__esModule = true;
var ko = require("knockout");
var SearchHeaderItem = (function () {
    function SearchHeaderItem(destinationCity, arrivalCity, datetime) {
        this.destinationCity = ko.observable(destinationCity);
        this.arrivalCity = ko.observable(arrivalCity);
        this.datetime = ko.observable(datetime);
    }
    return SearchHeaderItem;
}());
exports.SearchHeaderItem = SearchHeaderItem;
//# sourceMappingURL=SearchHeaderItem.js.map