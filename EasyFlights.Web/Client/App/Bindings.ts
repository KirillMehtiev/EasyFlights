import DatePickerBinding = require("./Common/Components/DatePicker/DatePickerBinding");
import AutocompleteBinding = require("./Common/Components/Autocomplete/AutocompleteBinding");
import IndicatorBinding = require("./Common/Components/BusyIndicator/BusyIndicatorBinding");

ko.bindingHandlers["datepicker"] = new DatePickerBinding();
ko.bindingHandlers["autoComplete"] = new AutocompleteBinding();
ko.bindingHandlers["busyIndicator"] = new IndicatorBinding();