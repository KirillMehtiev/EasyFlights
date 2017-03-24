"use strict";
var ko = require("knockout");
var FlightItem_1 = require("./FlightResults/FlightItem");
var Item = require("./FlightResults/Tickets/TicketItem");
var TicketItem = Item.TicketItem;
var SearchResultViewModel = (function () {
    function SearchResultViewModel() {
        this.flightItems = ko.observableArray([new FlightItem_1.FlightItem(12, "Flight", "Country", "Economy", "13:30", [new TicketItem(12, "Flight", "Country", "Economy", "rtt", "13:30", "City", "2 h 20 min", "15:50", "145")], 350, 100),
            new FlightItem_1.FlightItem(12, "Flight", "Country", "Lux", "14:30", [new TicketItem(13, "Flight", "Country", "Lux", "rtt", "14:30", "City", "2 h 30 min", "15:50", "145")], 120, 400),
            new FlightItem_1.FlightItem(12, "Flight", "Country", "Economy", "15:30", [new TicketItem(14, "Flight", "Country", "Economy", "rtt", "15:30", "City", "2 h 40 min", "15:50", "145")], 600, 200)]);
        this.createDefaultOptions();
        this.setPage();
        this.sortByPrice();
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
    SearchResultViewModel.prototype.sortByPrice = function () {
        this.flightItems.sort(function (x, y) { return x.totalCost - y.totalCost; });
        this.setPage();
    };
    SearchResultViewModel.prototype.sortByDuration = function () {
        this.flightItems.sort(function (x, y) { return x.totalDuration - y.totalDuration; });
        this.setPage();
    };
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