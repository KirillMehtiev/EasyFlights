import TicketsFlowBaseViewModel = require("../TicketsFlowBaseViewModel");
import { EditablePassengerOptions } from "../EditablePassengerOptions";
import { EditableTicketOptions } from "../EditableTicketOptions";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { IEditTicketsOptions } from "./IEditTicketsOptions";

class EditTicketsViewModel extends TicketsFlowBaseViewModel {

    public orderId: KnockoutObservable<number>;

    constructor(options: IEditTicketsOptions) {
        super();

        this.orderId = options.orderId;

        console.log(this.orderId());
    }

    protected initPassengerInfoList() {

        // TODO: get from server all required info

        this.ticketsFlowService.loadOrder(this.orderId().toString());

        // temp
        this.passengerInfoList = ko.observableArray([]);
        for (let i = 0; i < 4; i++) {
            this.passengerInfoList.push(new EditablePassengerOptions());
        }
    }
}

export = EditTicketsViewModel;