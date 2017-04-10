import TicketsFlowBaseViewModel = require("../TicketsFlowBaseViewModel");
import { EditablePassengerOptions } from "../EditablePassengerOptions";
import { EditableTicketOptions } from "../EditableTicketOptions";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "../BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { ITicketForBooking } from "../Services/ITicketForBooking";
import { IOrderTicketsOptions } from "./IOrderTicketsOptions";
import { AuthService } from "../../Common/Services/Auth/authService";

class OrderTicketsViewModel extends TicketsFlowBaseViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassengers: KnockoutObservable<number>;

    constructor(options: IOrderTicketsOptions) {
        super(options);

        this.routeId = options.routeId;
        this.numberOfPassengers = options.numberOfPassenger;

        this.bookTickets.bind(this);

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

    protected operationConfirmed() {
        this.bookTickets();
    }

    private createTicketsForPassenger(flights: Array<any>, passengerInfo: IEditablePassengerOptions): KnockoutObservableArray<IEditableTicketOptions> {
        let result = ko.observableArray([]);
        for (let i = 0; i < flights.length; i++) {
            let flight = flights[i];
            let ticket = new EditableTicketOptions();

            ticket.flightId = flight.flightId;

            ticket.departureAirport(flight.departureAirport);
            ticket.destinationAirport(flight.destinationAirport);
            ticket.duration(flight.duration);
            ticket.fare(flight.fare);
            ticket.departureTime(flight.departureTime);
            ticket.arrivalTime(flight.arrivalTime);
            ticket.firstName = passengerInfo.firstName;
            ticket.lastName = passengerInfo.lastName;

            result.push(ticket);
        }
        return result;
    }

    private bookTickets() {
        let data = this.collectDataAboutTickets();
        let dataKey: string = "filledData";

        if (AuthService.current.isCurrentUserSignedIn() === false) {
            window.localStorage.setItem(dataKey, JSON.stringify(data));
            window.location.href = "#sign-in";
            return;
        }

        this.isRequestProcessing(true);
        this.ticketsFlowService
            .bookTickets(data)
            .then(() => {
                window.localStorage.removeItem(dataKey);
                window.location.href = "#userCabinet";
            }).always(() => this.isRequestProcessing(false));
    }

    private collectDataAboutTickets(): Array<ITicketForBooking> {
        let result: Array<ITicketForBooking> = [];
        for (let i = 0; i < this.passengerInfoList().length; i++) {
            let passenger = this.passengerInfoList()[i];

            for (let j = 0; j < passenger.tickets().length; j++) {
                let ticket = passenger.tickets()[j];

                result.push({
                    flightId: ticket.flightId,
                    seat: ticket.seat(),
                    firstName: passenger.firstName(),
                    lastName: passenger.lastName(),
                    birthday: passenger.birthday(),
                    documentNumber: passenger.documentNumber(),
                    sex: passenger.sex().toString()
                });
            }
        }
        return result;
    }
}

export = OrderTicketsViewModel;