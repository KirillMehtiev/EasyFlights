import { RadioChooserItem } from "./RadioChooserItem";

export interface IRadioChooserOptions {
    options: Array<RadioChooserItem>;
    selectedOption: KnockoutObservable<string>;
}