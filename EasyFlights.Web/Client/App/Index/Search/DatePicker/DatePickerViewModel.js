"use strict";
var DatePickerViewModel = (function () {
    function DatePickerViewModel(options) {
        this.selectedDate = ko.observable("");
        this.label = options.label;
    }
    return DatePickerViewModel;
}());
module.exports = DatePickerViewModel;
//# sourceMappingURL=DatePickerViewModel.js.map