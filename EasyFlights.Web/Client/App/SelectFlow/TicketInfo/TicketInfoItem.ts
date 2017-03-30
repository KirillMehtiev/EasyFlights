import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export class TicketInfoItem {   
    passengers: KnockoutObservableArray<PassengerInfoItem>;
    ticketNumber: number;
    ticketClass: string;
    seat: number;
    price:number;
    constructor(passengers: KnockoutObservableArray<PassengerInfoItem>, ticketNumber: number, ticketClass: string, seat: number, price: number) {
        this.price = price;
        this.seat = seat;
        this.ticketClass = ticketClass;
        this.ticketNumber = ticketNumber;
        this.passengers = passengers;
    }
}