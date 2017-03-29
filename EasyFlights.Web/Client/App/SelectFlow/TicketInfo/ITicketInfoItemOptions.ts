import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export interface ITicketInfoItemOptions {
    passengers: KnockoutObservableArray<PassengerInfoItem>;
    ticketClass: string;
    ticketNumber: number;
    seat: number;
    price: number;
}