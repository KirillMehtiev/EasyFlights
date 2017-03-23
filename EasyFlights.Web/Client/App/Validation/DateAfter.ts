import validation = require("knockout.validation");
import moment = require("moment");
import {IValidationRule} from "./IValidationRule";

class DateAfter implements IValidationRule {

    public message: string = "Selected date has to be after {0}";

    public validator(inputValue: any, requiredValue: any) : boolean {
        let userSelectedDate = moment(inputValue);
        let requiredDate = moment(requiredValue);

        return userSelectedDate.isAfter(requiredDate);
    };
}

export = DateAfter;
