import validation = require("knockout.validation");
import moment = require("moment");

validation.rules["dateAfter"] = {
    validator: function (inputValue, requiredValue) {
        let userSelectedDate = moment(inputValue);
        let requiredDate = moment(requiredValue);

        let d = userSelectedDate.isAfter(requiredDate);
        console.log(d);

        return userSelectedDate.isAfter(requiredDate);
    },
    message: "Selected date has to be after {0}"
};