"use strict";
exports.__esModule = true;
var RouteItem = (function () {
    function RouteItem(id, departurePlace, destinationPlace, arrivalTime, departureTime, flights, totalCost, totalTime) {
        this.totalTime = totalTime;
        this.totalCost = totalCost;
        this.flights = flights;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime;
        this.destinationPlace = destinationPlace;
        this.departurePlace = departurePlace;
        this.id = id;
    }
    return RouteItem;
}());
exports.RouteItem = RouteItem;
//# sourceMappingURL=RouteItem.js.map