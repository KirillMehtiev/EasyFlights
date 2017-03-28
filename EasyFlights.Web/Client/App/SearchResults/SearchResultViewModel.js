"use strict";
var ko = require("knockout");
var RouteItem_1 = require("./FlightResults/RouteItem");
var RoutesService_1 = require("..//Common/Services/RoutesService");
var Item = require("./FlightResults/Tickets/FlightItem");
var FlightItem = Item.FlightItem;
var SearchResultViewModel = (function () {
    function SearchResultViewModel() {
        this.routesService = new RoutesService_1.RoutesService();
        this.routeItems = ko.observableArray([new RouteItem_1.RouteItem(12, "Flight", "Country", "Economy", "13:30", [new FlightItem(12, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145"), new FlightItem(13, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 350, 100),
            new RouteItem_1.RouteItem(12, "Flight", "Country", "Lux", "14:30", [new FlightItem(14, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 120, 400)]);
        this.createDefaultOptions();
        this.setPage();
        this.sortByPrice();
    }
    SearchResultViewModel.prototype.setPage = function () {
        this.pagedRouteItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;
        var pagedFlightItems = this.routeItems.slice(startIndex, endIndex);
        ko.utils.arrayPushAll(this.pagedRouteItems, pagedFlightItems);
    };
    ;
    SearchResultViewModel.prototype.sortByPrice = function () {
        this.routeItems.sort(function (x, y) { return x.totalCost - y.totalCost; });
        this.setPage();
    };
    SearchResultViewModel.prototype.sortByDuration = function () {
        this.routeItems.sort(function (x, y) { return x.totalTime - y.totalTime; });
        this.setPage();
    };
    SearchResultViewModel.prototype.createDefaultOptions = function () {
        this.pagedRouteItems = ko.observableArray([]);
        this.pageNo = ko.observable(1);
        this.pageSize = 2;
        this.total = this.routeItems().length;
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