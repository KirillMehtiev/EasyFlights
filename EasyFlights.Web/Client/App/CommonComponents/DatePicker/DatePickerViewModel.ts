import { IDatePickerOptions } from "./IDatePickerOptions";

class DatePickerViewModel {
    public selectedDate: KnockoutObservable<string>;
    public label: string;

    constructor(options: IDatePickerOptions) {
        this.selectedDate = options.selectedDate.extend({
            date: true
        });
        this.label = options.label;
    }
}

export = DatePickerViewModel;