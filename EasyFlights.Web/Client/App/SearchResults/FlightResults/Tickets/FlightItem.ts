import ko = require("knockout");
import {TicketInfoItem} from "../../../SelectFlow/TicketInfo/TicketInfoItem";

export class FlightItem {
    //public id: number;
    public arrivalTime: string;
    public departureAirport: string;
    public departureTime: string;
    public destinationAirport: string;    
    public duration: string;
    public fare: string;
    public tickets:KnockoutObservableArray<TicketInfoItem>;

    constructor(id: number, departureAirport: string, destinationAirport: string, departureTime: string, arrivalTime: string, duration: string, fare: string, tickets: KnockoutObservableArray<TicketInfoItem>) {
        //this.id = id;
        this.departureAirport = departureAirport;
        this.destinationAirport = destinationAirport;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime; 
        this.duration = duration;
        this.fare = fare;
        this.tickets = tickets;
    }
}