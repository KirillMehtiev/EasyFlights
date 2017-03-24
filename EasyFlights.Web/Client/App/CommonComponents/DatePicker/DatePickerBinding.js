"use strict";
var ko = require("knockout");
var $ = require("jquery");
var moment = require("moment");
var DatePickerBinding = (function () {
    function DatePickerBinding() {
    }
    DatePickerBinding.prototype.init = function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().datepickerOptions || {};
        var $element = $(element);
        $element.datepicker(options);
        $element.on("change", function (event) {
            var choosenDate = $(event.target).datepicker("getDate");
            var value = moment(choosenDate).format("L");
            var observable = allBindingsAccessor().value;
            observable(value);
        });
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $element.datepicker("destroy");
        });
    };
    DatePickerBinding.prototype.update = function (element, valueAccessor) {
    };
    return DatePickerBinding;
}());
module.exports = DatePickerBinding;
//# sourceMappingURL=DatePickerBinding.js.map