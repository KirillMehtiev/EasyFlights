import validation = require("knockout.validation");
import DateAfterValidationRule = require("./Validation/DateAfterValidationRule");
import AreSameValidationRule = require("./Validation/AreSameValidationRule");
import PasswordValidationRule = require("./Validation/PasswordValidation/PasswordValidationRule");

validation.rules["dateAfter"] = new DateAfterValidationRule();
validation.rules["areSame"] = new AreSameValidationRule();
validation.rules["password"] = new PasswordValidationRule();