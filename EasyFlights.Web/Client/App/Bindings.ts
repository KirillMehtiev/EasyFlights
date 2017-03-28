import DatePickerBinding = require("./Common/Components/DatePicker/DatePickerBinding");
import AutocompleteBinding = require("./Common/Components/Autocomplete/AutocompleteBinding");

ko.bindingHandlers["datepicker"] = new DatePickerBinding();
ko.bindingHandlers["autoComplete"] = new AutocompleteBinding();