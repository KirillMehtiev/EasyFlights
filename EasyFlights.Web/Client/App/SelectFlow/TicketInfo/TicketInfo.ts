export class TicketDescription {
    public fare: string;
    public discount: number;
    public seat: number;
    public class: string;
    public passenger: string;
}

export class TicketInfoFlight {
    public arrivalTime: string;
    public departureAirport: string;
    public departureTime: string;
    public destinationAirport: string;
    public duration: string;
    public fare: string;
    public tickets: Array<TicketDescription>;
}
 
export class TicketInfoGeneral {
    public departureAirport: string;
    public departureCity: string;
    public arrivalAirport: string;
    public arrivalCity: string;
    public duration: string;
    public totalPrice: string;
    public flights: Array<TicketInfoFlight>;
}