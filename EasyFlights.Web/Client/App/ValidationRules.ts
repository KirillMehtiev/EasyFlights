import validation = require("knockout.validation");
import DateAfterValidationRule = require("./Validation/DateAfterValidationRule");
import DateBeforeValidationRule = require("./Validation/DateBeforeValidationRule");
import AreSameValidationRule = require("./Validation/AreSameValidationRule");
import PasswordValidationRule = require("./SignUp/PasswordValidation/PasswordValidationRule");
import NotSameValidationRule = require("./Validation/AreNotSameValidationRule");

validation.rules["dateAfter"] = new DateAfterValidationRule();
validation.rules["dateBefore"] = new DateBeforeValidationRule();
validation.rules["areSame"] = new AreSameValidationRule();
validation.rules["areNotSame"] = new NotSameValidationRule();
validation.rules["password"] = new PasswordValidationRule();