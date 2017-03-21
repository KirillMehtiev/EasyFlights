import { IDatePickerOptions } from "./IDatePickerOptions";

class DatePickerViewModel {
    selectedDate: KnockoutObservable<string>;
    label: string;

    constructor(options: IDatePickerOptions) {
        this.selectedDate = ko.observable("");
        this.label = options.label;
    }
}

export = DatePickerViewModel;