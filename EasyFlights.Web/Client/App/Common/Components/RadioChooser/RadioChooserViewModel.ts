import { IRadioChooserOptions } from "./IRadioChooserOptions";
import { RadioChooserItem } from "./RadioChooserItem";

class RadioChooserViewModel {
    public options: Array<RadioChooserItem>;
    public selectedOption: KnockoutObservable<string>;

    constructor(params: IRadioChooserOptions) {
        this.options = params.options;
        this.selectedOption = params.selectedOption;
    }

}

export = RadioChooserViewModel;