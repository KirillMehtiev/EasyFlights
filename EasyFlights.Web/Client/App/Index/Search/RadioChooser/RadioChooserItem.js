"use strict";
exports.__esModule = true;
var ko = require("knockout");
var RadioItem = (function () {
    function RadioItem(label, value) {
        this.label = ko.observable(label);
        this.value = ko.observable(value);
    }
    return RadioItem;
}());
exports.RadioItem = RadioItem;
//# sourceMappingURL=RadioChooserItem.js.map