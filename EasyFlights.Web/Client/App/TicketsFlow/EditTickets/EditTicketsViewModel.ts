import TicketsFlowBaseViewModel = require("../TicketsFlowBaseViewModel");
import { EditablePassengerOptions } from "../EditablePassengerOptions";
import { EditableTicketOptions } from "../EditableTicketOptions";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";

class EditTicketsViewModel extends TicketsFlowBaseViewModel {

    constructor(options) {
        super(options);
    }

    protected initPassengerInfoList(routeId: string, numberOfPassenger: number) {
        this.passengerInfoList = ko.observableArray([]);
        for (let i = 0; i < numberOfPassenger; i++) {

            // TODO: get from sever all required info

            this.passengerInfoList.push(new EditablePassengerOptions());
        }
    }
}

export = EditTicketsViewModel;