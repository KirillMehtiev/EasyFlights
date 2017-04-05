import { IPassengerInfoItem } from "./IPassengerInfoItem";

export interface IPassengerInfoOptions {
    passangerInfoList: KnockoutObservableArray<IPassengerInfoItem>;
    onNextStep: KnockoutSubscribable<number>;
}