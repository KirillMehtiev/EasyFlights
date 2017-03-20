"use strict";
var ko = require("knockout");
var LayoutViewModel = (function () {
    function LayoutViewModel(options) {
        this.title = ko.observable(options.title);
    }
    return LayoutViewModel;
}());
module.exports = LayoutViewModel;
//# sourceMappingURL=LayoutViewModel.js.map