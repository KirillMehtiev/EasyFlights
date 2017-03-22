import { IDatePickerOptions } from "./IDatePickerOptions";

class DatePickerViewModel {
    selectedDate: KnockoutObservable<string>;
    label: string;

    constructor(options: IDatePickerOptions) {
        this.selectedDate = options.selectedDate;
        this.label = options.label;
    }
}

export = DatePickerViewModel;