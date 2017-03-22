"use strict";
var ko = require("knockout");
var RadioChooserItem_1 = require("./RadioChooser/RadioChooserItem");
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
        this.selectedTicketType = ko.observable(TicketType.oneWay);
    }
    return SearchViewModel;
}());
module.exports = SearchViewModel;
//# sourceMappingURL=SearchViewModel.js.map