import { IDatePickerOptions } from "./IDatePickerOptions";

class DatePickerViewModel {
    public selectedDate: KnockoutObservable<string>;
    public label: string;
    public name:string;

    constructor(options: IDatePickerOptions) {
        this.selectedDate = options.selectedDate.extend({
            date: true
        });
        this.label = options.label;
        this.name = options.name;
    }
}

export = DatePickerViewModel;