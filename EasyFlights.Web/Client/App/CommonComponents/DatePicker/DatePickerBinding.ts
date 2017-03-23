import ko = require("knockout");
import $ = require("jquery");
import moment = require("moment");
import {IKnockoutBinding} from "../IKnockoutBinding";

class DatePickerBinding implements IKnockoutBinding {
    public init(element: any, valueAccessor: any, allBindingsAccessor: any): void {
        let options = allBindingsAccessor().datepickerOptions || {};
        let $element = $(element);

        // setup datepicker
        $element.datepicker(options);

        // handle the field changing
        $element.on("change", (event) => {
            let choosenDate = $(event.target).datepicker("getDate");
            let value = moment(choosenDate).format("L");
            let observable = allBindingsAccessor().value;

            observable(value);
        });

        // handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, () => {
            $element.datepicker("destroy");
        });
    }

    public update(element: any, valueAccessor: any): void {
        
    }
}

export = DatePickerBinding;