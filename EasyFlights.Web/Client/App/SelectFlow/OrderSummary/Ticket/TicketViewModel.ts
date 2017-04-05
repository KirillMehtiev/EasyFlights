import { ITicketOptions } from "./ITicketOptions";
import { IEditablePassengerOptions } from "../../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

class TicketViewModel {

    public passenger: IEditablePassengerOptions;

    constructor(options: ITicketOptions) {
        this.passenger = options.passenger;
    }

}

export = TicketViewModel;