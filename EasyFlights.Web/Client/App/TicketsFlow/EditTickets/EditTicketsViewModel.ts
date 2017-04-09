import TicketsFlowBaseViewModel = require("../TicketsFlowBaseViewModel");
import { EditablePassengerOptions } from "../EditablePassengerOptions";
import { EditableTicketOptions } from "../EditableTicketOptions";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { IEditTicketsOptions } from "./IEditTicketsOptions";

class EditTicketsViewModel extends TicketsFlowBaseViewModel {

    public orderId: KnockoutObservable<number>;

    constructor(options: IEditTicketsOptions) {
        super(options);

        this.orderId = options.orderId;

        // dirty hack :)
        this.init();
    }

    protected initPassengerInfoList() {

        // TODO: get from server all required info
        this.passengerInfoList = ko.observableArray([]);
        this.ticketsFlowService.loadOrder(this.orderId().toString()).then((editablePassengers) => {
            console.log(editablePassengers);
            for (let i = 0; i < editablePassengers.length; i++) {
                let initPassenger = editablePassengers[i];
                let passenger = new EditablePassengerOptions();

                passenger.firstName(initPassenger.firstName);
                passenger.lastName(initPassenger.lastName);
                passenger.sex(initPassenger.sex);
                passenger.birthday(initPassenger.birthday);
                passenger.documentNumber(initPassenger.documentNumber);

                passenger.tickets = ko.observableArray([]);

                for (let j = 0; j < initPassenger.tickets.length; j++) {
                    let initTicket = initPassenger.tickets[j];
                    let ticket = new EditableTicketOptions();

                    ticket.flightId = initTicket.flightId;

                    ticket.firstName = passenger.firstName;
                    ticket.lastName = passenger.lastName;
                    ticket.departureAirport(initTicket.departureAirport);
                    ticket.destinationAirport(initTicket.destinationAirport);
                    ticket.departureTime(initTicket.departureTime);
                    ticket.fare(initTicket.fare);
                    ticket.duration(initTicket.duration);
                    ticket.seat(initTicket.seat);

                    passenger.tickets.push(ticket);
                }

                this.passengerInfoList.push(passenger);
            }
        });

        //// temp

        //for (let i = 0; i < 1; i++) {
        //    this.passengerInfoList.push(new EditablePassengerOptions());
        //}
    }

    protected operationConfirmed() {

        console.log("confirm from edit");
    }
}

export = EditTicketsViewModel;