"use strict";
exports.__esModule = true;
var ko = require("knockout");
var FlightItem = (function () {
    function FlightItem(id, flight, country, flightType, departure, duration, arrival, cityArrival) {
        this.id = id;
        this.flight = ko.observable(flight);
        this.country = ko.observable(country);
        this.flightType = ko.observable(flightType);
        this.departure = ko.observable(departure);
        this.duration = ko.observable(duration);
        this.arrival = ko.observable(arrival);
        this.cityArrival = ko.observable(cityArrival);
    }
    return FlightItem;
}());
exports.FlightItem = FlightItem;
//# sourceMappingURL=FlightItem.js.map