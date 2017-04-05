import { Sex } from "../../../Common/Enum/Enums";
import { IEditableTicketOptions } from "../../TicketInfo/EditableTicket/IEditableTicketOptions";

export interface IEditablePassengerOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    birthday: KnockoutObservable<string>;
    documentNumber: KnockoutObservable<string>;
    sex: KnockoutObservable<Sex>;
    tickets: KnockoutObservableArray<IEditableTicketOptions>;
}