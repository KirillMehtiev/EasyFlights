import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"

export interface ITicketInfoItemOptions {
    passengers: KnockoutObservableArray<PassengerInfoItem>;
    flights: KnockoutObservableArray<RouteItem>;
    ticketClass: string;
    ticketNumber: number;
    seat: number;
    price: number;
}