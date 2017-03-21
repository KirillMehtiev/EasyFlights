"use strict";
var RadioChooserViewModel = (function () {
    function RadioChooserViewModel() {
        var preselected = "one-way";
        this.selectedOption = ko.observable(preselected);
    }
    return RadioChooserViewModel;
}());
module.exports = RadioChooserViewModel;
//# sourceMappingURL=RadioChooserViewModel.js.map