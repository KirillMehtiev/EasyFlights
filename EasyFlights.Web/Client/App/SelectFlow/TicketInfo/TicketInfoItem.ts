import ko = require("knockout");
import { FlightItem } from "../../SearchResults/FlightResults/Tickets/FlightItem";

export class TicketInfoItem {
    public departureAirport: string;
    public departureCity: string;
    public arrivalAirport: string;
    public arrivalCity: string;
    public duration: string;
    public totalPrice: string;

    public flights: Array<FlightItem>;
    constructor(id: number, departurePlace: string, destinationPlace: string, arrivalTime: string, departureTime: string, flights: Array<FlightItem>, totalCost: any, totalTime: any) {

    }
}