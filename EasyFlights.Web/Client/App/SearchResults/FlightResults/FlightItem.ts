import ko = require("knockout");
import Item = require("./Tickets/TicketItem");
import TicketItem = Item.TicketItem;

export class FlightItem {
    public id: number;
    public departureDate: string;
    public arrivalDate: string;
    public departureAirport: string;
    public arrivalAirport: string;
    public tickets: Array<TicketItem>;
   

    constructor(id: number, departureDate: string, arrivalDate: string, departureAirport: string, arrivalAirport: string, tickets: Array<TicketItem>) {
        this.id = id;
        this.tickets = tickets;
        this.arrivalAirport = arrivalAirport;
        this.departureAirport = departureAirport;
        this.arrivalDate = arrivalDate;
        this.departureDate = departureDate;
       
       
        
  
        
    }
}