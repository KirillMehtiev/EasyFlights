import PassengerInfoItem = require("../PassengerInfo/PassengerInfoItem");

export class TicketInfoItem {   
    passenger: PassengerInfoItem;
    ticketNumber: number;
    ticketClass: string;
    seat: number;
    price:number;
    constructor(passenger: PassengerInfoItem, ticketNumber: number, ticketClass: string, seat: number, price: number) {
        this.price = price;
        this.seat = seat;
        this.ticketClass = ticketClass;
        this.ticketNumber = ticketNumber;
        this.passenger = passenger;
    }
}