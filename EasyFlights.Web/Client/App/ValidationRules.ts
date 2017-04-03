import validation = require("knockout.validation");
import DateAfterValidationRule = require("./Validation/DateAfterValidationRule");
import AreSameValidationRule = require("./Validation/AreSameValidationRule");

validation.rules["dateAfter"] = new DateAfterValidationRule();
validation.rules["areSame"] = new AreSameValidationRule();
