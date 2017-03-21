import { RadioItem } from "./RadioChooserItem";

export interface IRadioChooserOptions {
    options: Array<RadioItem>;
    preselected: KnockoutObservable<string>;
}