import { TicketClass } from "../../../../Common/Enum/Enums";

export interface IEditableTicketOptions {
    departureAirport: KnockoutObservable<string>;
    destinationAirport: KnockoutObservable<string>;
    seatChosen: KnockoutObservableArray<number>;
    duration: KnockoutObservable<string>;
    fare: KnockoutObservable<string>;
    departureTime: KnockoutObservable<string>;
    arrivalTime: KnockoutObservable<string>;
    seat: KnockoutObservable<number>;
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    flightId: number;
}
