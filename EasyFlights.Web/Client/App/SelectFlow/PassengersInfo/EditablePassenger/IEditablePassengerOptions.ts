import { Sex } from "../../../Common/Enum/Enums";

export interface IEditablePassengerOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    birthday: KnockoutObservable<string>;
    documentNumber: KnockoutObservable<string>;
    sex: KnockoutObservable<Sex>;
}