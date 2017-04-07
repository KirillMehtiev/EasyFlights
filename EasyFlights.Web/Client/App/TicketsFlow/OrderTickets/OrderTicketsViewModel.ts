import TicketsFlowBaseViewModel = require("../TicketsFlowBaseViewModel");
import { EditablePassengerOptions } from "../EditablePassengerOptions";
import { EditableTicketOptions } from "../EditableTicketOptions";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { IOrderTicketsOptions } from "./IOrderTicketsOptions";

class OrderTicketsViewModel extends TicketsFlowBaseViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassengers: KnockoutObservable<number>;

    constructor(options: IOrderTicketsOptions) {
        super(options);

        this.routeId = options.routeId;
        this.numberOfPassengers = options.numberOfPassenger;

        // dirty hack :)
        this.init();
    }

    protected initPassengerInfoList() {
    this.passengerInfoList = ko.observableArray([]);
    for (let i = 0; i < this.numberOfPassengers(); i++) {
        this.passengerInfoList.push(new EditablePassengerOptions());
    }

    this.ticketsFlowService
        .loadRoute(this.routeId())
        .then((route => {
            for (let i = 0; i < this.passengerInfoList().length; i++) {
                let passenger = this.passengerInfoList()[i];
                passenger.tickets = this.createTicketsForPassenger(route.flights, passenger);
            }
        }));
    }

    private createTicketsForPassenger(flights: Array<any>, passengerInfo: IEditablePassengerOptions): KnockoutObservableArray<IEditableTicketOptions> {
        let result = ko.observableArray([]);
        for (let i = 0; i < flights.length; i++) {
            let flight = flights[i];
            let ticket = new EditableTicketOptions();

            ticket.departureAirport(flight.departureAirport);
            ticket.destinationAirport(flight.destinationAirport);
            ticket.duration(flight.duration);
            ticket.fare(flight.fare);
            ticket.departureTime(flight.departureTime);

            ticket.firstName = passengerInfo.firstName;
            ticket.lastName = passengerInfo.lastName;

            result.push(ticket);
        }
        return result;
    }
}

export = OrderTicketsViewModel;