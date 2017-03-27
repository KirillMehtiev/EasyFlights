import moment = require("moment");
import { ISingleValueValidationRule } from "./ISingleValueValidationRule";

class DateAfterValidationRule implements ISingleValueValidationRule<string> {

    public message: string = "Selected date has to be after {0}";

    public validator(inputValue: string, requiredValue: string) : boolean {
        let userSelectedDate = moment(inputValue);
        let requiredDate = moment(requiredValue);

        return userSelectedDate.isAfter(requiredDate);
    };
}

export = DateAfterValidationRule;
