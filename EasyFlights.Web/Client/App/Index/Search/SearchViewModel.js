"use strict";
var ko = require("knockout");
var moment = require("moment");
var RadioChooserItem_1 = require("./RadioChooser/RadioChooserItem");
var Item = require("./Autocomplete/CityItem/CityItem");
var TicketType = (function () {
    function TicketType() {
    }
    return TicketType;
}());
TicketType.oneWay = "OneWay";
TicketType.roundTrip = "RoundTrip";
var SearchViewModel = (function () {
    function SearchViewModel() {
        this.options = [
            new RadioChooserItem_1.RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem_1.RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.cityList = [new Item.CityItem("City 1", 1), new Item.CityItem("City 2", 2)];
        this.selectedTicketType = ko.observable(TicketType.oneWay);
        this.selectedDepartureDate = ko.observable("").extend({
            dateAfter: moment().format("L")
        });
        this.selectedReturnDate = ko.observable("").extend({
            dateAfter: moment().add(1, "day").format("L")
        });
        this.searchCityFrom = ko.observable();
        this.searchCityTo = ko.observable();
        this.isRoundTripSelected = ko.observable(false);
        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
    }
    SearchViewModel.prototype.onTicketTypeChanged = function (newValue) {
        this.isRoundTripSelected(newValue === TicketType.roundTrip);
        if (!this.isRoundTripSelected()) {
            this.selectedReturnDate("");
        }
    };
    return SearchViewModel;
}());
module.exports = SearchViewModel;
//# sourceMappingURL=SearchViewModel.js.map