import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export interface ITicketInfoItemOptions {
    passengers: Array<PassengerInfoItem>;
    ticketClass: string;
    ticketNumber: number;
    seat: number;
    price: number;
}