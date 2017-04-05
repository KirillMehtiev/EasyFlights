import { TicketInfoItem } from "./TicketInfoItem";
import { IEditableTicketOptions } from "./EditableTicket/IEditableTicketOptions";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

export interface ITicketInfoItemOptions {
    passengersInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    ticketsInfoList: KnockoutObservableArray<IEditableTicketOptions>;
    onNextStep: KnockoutSubscribable<number>;
    onPreviousStep: KnockoutSubscribable<number>;
}