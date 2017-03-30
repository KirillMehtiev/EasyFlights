import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export interface ITicketInfoItemOptions {
    passenger: PassengerInfoItem;
    ticketClass: string;
    ticketNumber: number;
    seat: number;
    price: number;
}