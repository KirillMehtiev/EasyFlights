"use strict";
var ko = require("knockout");
var FlightItem_1 = require("./FlightResults/FlightItem");
var SearchResultViewModel = (function () {
    function SearchResultViewModel() {
        this.flightItems = ko.observableArray([new FlightItem_1.FlightItem(12, "Flight", "Country", "Economy", "13:30", "City", "2 h 20 min", "15:50"),
            new FlightItem_1.FlightItem(13, "Flight", "Country", "Economy", "13:30", "City", "2 h 30 min", "16:50"),
            new FlightItem_1.FlightItem(14, "Flight", "Country", "Economy", "13:30", "City", "2 h 40 min", "16:50")
        ]);
        this.createDefaultOptions();
        this.setPage();
    }
    SearchResultViewModel.prototype.setPage = function () {
        this.pagedFlightItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;
        var pagedFlightItems = this.flightItems.slice(startIndex, endIndex);
        for (var i = 0; i < pagedFlightItems.length; i++) {
            this.pagedFlightItems.push(pagedFlightItems[i]);
        }
    };
    ;
    SearchResultViewModel.prototype.createDefaultOptions = function () {
        this.pagedFlightItems = ko.observableArray([]);
        this.pageNo = ko.observable(1);
        this.pageSize = 2;
        this.total = this.flightItems().length;
        this.maxPages = 5;
        this.directions = true;
        this.boundary = true;
        this.text = {
            first: 'First',
            last: 'Last',
            back: '«',
            forward: '»'
        };
    };
    return SearchResultViewModel;
}());
module.exports = SearchResultViewModel;
//# sourceMappingURL=SearchResultViewModel.js.map