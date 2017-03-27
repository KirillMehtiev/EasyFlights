import ko = require("knockout");
import $ = require("jquery");
import moment = require("moment");

class DatePickerBinding implements KnockoutBindingHandler {
    public init(element: any, valueAccessor: any, allBindingsAccessor: KnockoutAllBindingsAccessor): void {
        let options = allBindingsAccessor().datepickerOptions || {};
        let $element: JQuery = $(element);

        // setup datepicker
        $element.datepicker(options);

        // handle the field changing
        $element.on("change", (event) => {
            let choosenDate: Date = $(event.target).datepicker("getDate");
            let value: string = moment(choosenDate).format("L");
            let observable: KnockoutObservable<string> = allBindingsAccessor().value;

            observable(value);
        });

        // handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, () => {
            $element.datepicker("destroy");
        });
    }
}

export = DatePickerBinding;