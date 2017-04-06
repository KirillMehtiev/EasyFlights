import { ITicketOptions } from "./ITicketOptions";
import { IEditablePassengerOptions } from "../../PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../../TicketInfo/EditableTicket/IEditableTicketOptions";

class TicketViewModel {
    public passenger: IEditablePassengerOptions;
    public ticket: IEditableTicketOptions;

    constructor(options: ITicketOptions) {
        this.passenger = options.passenger;
        this.ticket = options.passenger.tickets()[options.ticketIndex()];
    }
}

export = TicketViewModel;