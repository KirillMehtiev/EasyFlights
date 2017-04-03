import ko = require("knockout");
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export class TicketInfoItem {   
    public passenger: PassengerInfoItem;
    public ticketNumber: number;
    public ticketClass: KnockoutObservable<string>;
    public seat: KnockoutObservable<number>;
    public price: KnockoutObservable<number>;
    constructor(passenger:PassengerInfoItem, ticketNumber: number, ticketClass: string, seat: number, price: number) {
        this.price = ko.observable(price);
        this.seat = ko.observable(seat);
        this.ticketClass = ko.observable(ticketClass);
        this.ticketNumber = ticketNumber;
        this.passenger = passenger;
    }
}