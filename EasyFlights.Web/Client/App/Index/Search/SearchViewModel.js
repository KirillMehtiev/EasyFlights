"use strict";
var ko = require("knockout");
var RadioChooserItem_1 = require("./RadioChooser/RadioChooserItem");
var SearchViewModel = (function () {
    function SearchViewModel() {
        this.options = [
            new RadioChooserItem_1.RadioItem("One Way", "one-way"),
            new RadioChooserItem_1.RadioItem("Round trip", "round-trip")
        ];
        this.selectedTicketType = ko.observable("one-way");
    }
    return SearchViewModel;
}());
module.exports = SearchViewModel;
//# sourceMappingURL=SearchViewModel.js.map