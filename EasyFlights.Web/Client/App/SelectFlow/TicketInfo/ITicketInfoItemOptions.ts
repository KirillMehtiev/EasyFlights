import { IInternalNavigation } from "../IInternalNavigation";
import { TicketInfoItem } from "./TicketInfoItem";
import { IEditableTicketOptions } from "./EditableTicket/IEditableTicketOptions";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

export interface ITicketInfoItemOptions extends IInternalNavigation {
    passengersInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    ticketsInfoList: KnockoutObservableArray<IEditableTicketOptions>;
}