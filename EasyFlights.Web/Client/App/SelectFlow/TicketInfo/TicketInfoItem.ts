import ko = require("knockout");
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export class TicketInfoItem {   
    passenger: PassengerInfoItem;
    ticketNumber: number;
    ticketClass: KnockoutObservable<string>;
    seat: KnockoutObservable<number>;
    price: KnockoutObservable<number>;
    constructor(passenger:PassengerInfoItem, ticketNumber: number, ticketClass: string, seat: number, price: number) {
        this.price = ko.observable(price);
        this.seat = ko.observable(seat);
        this.ticketClass = ko.observable(ticketClass);
        this.ticketNumber = ticketNumber;
        this.passenger = passenger;
    }
}