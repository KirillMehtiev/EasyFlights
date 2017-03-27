import { IDatePickerOptions } from "./IDatePickerOptions";

class DatePickerViewModel {
    public selectedDate: KnockoutObservable<string>;
    public name:string;

    constructor(options: IDatePickerOptions) {
        this.selectedDate = options.selectedDate.extend({
            date: true
        });
        this.name = options.name;
    }
}

export = DatePickerViewModel;