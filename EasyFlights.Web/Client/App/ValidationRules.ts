import validation = require("knockout.validation");
import DateAfter = require("./Validation/DateAfter");

validation.rules["dateAfter"] = new DateAfter();
