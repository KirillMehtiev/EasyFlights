import validation = require("knockout.validation");
import DateAfterValidationRule = require("./Validation/DateAfterValidationRule");

validation.rules["dateAfter"] = new DateAfterValidationRule();
