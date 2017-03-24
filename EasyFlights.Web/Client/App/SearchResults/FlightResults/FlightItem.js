"use strict";
exports.__esModule = true;
var FlightItem = (function () {
    function FlightItem(id, departureDate, arrivalDate, departureAirport, arrivalAirport, tickets, totalCost, totalDuration) {
        this.id = id;
        this.tickets = tickets;
        this.arrivalAirport = arrivalAirport;
        this.departureAirport = departureAirport;
        this.arrivalDate = arrivalDate;
        this.departureDate = departureDate;
        this.totalCost = totalCost;
        this.totalDuration = totalDuration;
    }
    return FlightItem;
}());
exports.FlightItem = FlightItem;
//# sourceMappingURL=FlightItem.js.map