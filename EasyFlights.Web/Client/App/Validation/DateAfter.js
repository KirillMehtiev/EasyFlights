"use strict";
var moment = require("moment");
var DateAfter = (function () {
    function DateAfter() {
        this.message = "Selected date has to be after {0}";
    }
    DateAfter.prototype.validator = function (inputValue, requiredValue) {
        var userSelectedDate = moment(inputValue);
        var requiredDate = moment(requiredValue);
        return userSelectedDate.isAfter(requiredDate);
    };
    ;
    return DateAfter;
}());
module.exports = DateAfter;
//# sourceMappingURL=DateAfter.js.map