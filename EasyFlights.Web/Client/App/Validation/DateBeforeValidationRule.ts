import moment = require("moment");
import { ISingleValueValidationRule } from "./ISingleValueValidationRule";

class DateBeforeValidationRule implements ISingleValueValidationRule<string> {

    public message: string = "Selected date has to be before {0}";

    public validator(inputValue: string, requiredValue: string) : boolean {
        let userSelectedDate = moment(inputValue);
        let requiredDate = moment(requiredValue);

        return userSelectedDate.isBefore(requiredDate);
    };
}

export = DateBeforeValidationRule;
