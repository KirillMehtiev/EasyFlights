import { IPassengerInfoItem } from "../PassengerInfo/IPassengerInfoItem";
import { TicketInfoItem } from "./TicketInfoItem";

export interface ITicketInfoItemOptions {
    ticketInfoList: Array<TicketInfoItem>;
    onNextStep: KnockoutSubscribable<number>;
    onPreviousStep: KnockoutSubscribable<number>;
}