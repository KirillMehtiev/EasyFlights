import { IEditablePassengerOptions } from "./EditablePassenger/IEditablePassengerOptions";

export interface IPassengersInfoOptions {
    passangerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    onNextStep: KnockoutSubscribable<number>;
}