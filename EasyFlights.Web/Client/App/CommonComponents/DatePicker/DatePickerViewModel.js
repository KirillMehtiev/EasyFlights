"use strict";
var DatePickerViewModel = (function () {
    function DatePickerViewModel(options) {
        this.selectedDate = options.selectedDate.extend({
            date: true
        });
        this.label = options.label;
        this.name = options.name;
    }
    return DatePickerViewModel;
}());
module.exports = DatePickerViewModel;
//# sourceMappingURL=DatePickerViewModel.js.map