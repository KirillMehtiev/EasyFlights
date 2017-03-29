"use strict";
var ko = require("knockout");
var moment = require("moment");
var RadioChooserItem_1 = require("../../Common/Components/RadioChooser/RadioChooserItem");
var TicketType = (function () {
    function TicketType() {
    }
    return TicketType;
}());
TicketType.oneWay = "OneWay";
TicketType.roundTrip = "RoundTrip";
var DatePickerType = (function () {
    function DatePickerType() {
    }
    return DatePickerType;
}());
DatePickerType.departureDate = "departureDate";
DatePickerType.returnDate = "returnDate";
var SearchViewModel = (function () {
    function SearchViewModel() {
        this.placeholderAutocomplete = "Search by country, city or airport";
        this.options = [
            new RadioChooserItem_1.RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem_1.RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.createDefaultOptions();
        this.departureDateName = ko.observable(DatePickerType.departureDate);
        this.returnDateName = ko.observable(DatePickerType.returnDate);
        this.selectedTicketType = ko.observable(TicketType.oneWay);
        this.selectedDepartureDate = ko.observable("").extend({
            dateAfter: moment().format("L")
        });
        var self = this;
        this.selectedReturnDate = ko.observable("").extend({
            dateAfter: self.selectedDepartureDate
        });
        this.searchAirportFrom = ko.observable().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });
        this.searchAirportTo = ko.observable().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });
        this.isRoundTripSelected = ko.observable(false);
        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
    }
    SearchViewModel.prototype.onTicketTypeChanged = function (newValue) {
        this.isRoundTripSelected(newValue === TicketType.roundTrip);
        if (!this.isRoundTripSelected()) {
            this.selectedReturnDate("");
        }
    };
    SearchViewModel.prototype.createDefaultOptions = function () {
        this.count = ko.observable(1);
        this.numberOfPeople = ko.observableArray();
        for (var i = 1; i < 10; i++) {
            this.numberOfPeople.push(i);
        }
    };
    return SearchViewModel;
}());
module.exports = SearchViewModel;
//# sourceMappingURL=SearchViewModel.js.map