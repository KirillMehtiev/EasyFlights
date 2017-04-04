import { PassengerInfoItem } from "./PassengerInfoItem";

export interface IPassengerInfoOptions {
    passangerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    onNextStep: KnockoutSubscribable<number>;
}