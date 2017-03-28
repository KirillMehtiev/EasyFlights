"use strict";
var moment = require("moment");
var DateAfterValidationRule = (function () {
    function DateAfterValidationRule() {
        this.message = "Selected date has to be after {0}";
    }
    DateAfterValidationRule.prototype.validator = function (inputValue, requiredValue) {
        var userSelectedDate = moment(inputValue);
        var requiredDate = moment(requiredValue);
        return userSelectedDate.isAfter(requiredDate);
    };
    ;
    return DateAfterValidationRule;
}());
module.exports = DateAfterValidationRule;
//# sourceMappingURL=DateAfterValidationRule.js.map