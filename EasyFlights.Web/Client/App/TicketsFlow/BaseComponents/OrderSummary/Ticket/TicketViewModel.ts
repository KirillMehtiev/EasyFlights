import ko = require("knockout");
import { ITicketOptions } from "./ITicketOptions";
import { IEditablePassengerOptions } from "../../PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../../TicketInfo/EditableTicket/IEditableTicketOptions";
import { Sex } from "../../../../Common/Enum/Enums";

class TicketViewModel {
    public passenger: IEditablePassengerOptions;
    public ticket: IEditableTicketOptions;
    public passengerSex: KnockoutComputed<string>;

    constructor(options: ITicketOptions) {
        this.passenger = options.passenger;
        this.ticket = options.passenger.tickets()[options.ticketIndex()];

        this.passengerSex = ko.computed(() => this.convertPassengerSexToString());
    }

    public convertPassengerSexToString() {
        switch (this.passenger.sex()) {
            case Sex.Male:
                return "Male";
            case Sex.Female:
                return "Female";
            default:
                return "Unknown gender";
        }
    }
}

export = TicketViewModel;