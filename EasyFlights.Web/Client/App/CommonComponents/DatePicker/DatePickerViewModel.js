"use strict";
var DatePickerViewModel = (function () {
    function DatePickerViewModel(options) {
        this.selectedDate = options.selectedDate.extend({
            date: true
        });
        this.label = options.label;
    }
    return DatePickerViewModel;
}());
module.exports = DatePickerViewModel;
//# sourceMappingURL=DatePickerViewModel.js.map