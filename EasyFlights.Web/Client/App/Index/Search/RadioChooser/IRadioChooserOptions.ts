import { RadioItem } from "./RadioChooserItem";

export interface IRadioChooserOptions {
    options: Array<RadioItem>;
    selectedOption: KnockoutObservable<string>;
}