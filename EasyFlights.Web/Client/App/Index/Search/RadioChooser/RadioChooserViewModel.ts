import ko = require("knockout");
import { IRadioChooserOptions } from "./IRadioChooserOptions";
import { RadioItem } from "./RadioChooserItem";

class RadioChooserViewModel {
    public options: Array<RadioItem>;
    public selectedOption: KnockoutObservable<string>;

    constructor(params: IRadioChooserOptions) {
        this.options = params.options;
        this.selectedOption = params.preselected;
    }

}

export = RadioChooserViewModel;