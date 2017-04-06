import { TicketClass } from "../../../Common/Enum/Enums";

export interface IEditableTicketOptions {
    departureAirport: KnockoutObservable<string>;
    destinationAirport: KnockoutObservable<string>;
    duration: KnockoutObservable<string>;
    fare: KnockoutObservable<string>;
    departureTime: KnockoutObservable<string>;
    seat: KnockoutObservable<number>;
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
}
