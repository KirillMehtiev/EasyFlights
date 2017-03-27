import ko = require("knockout");
import Item = require("./Tickets/FlightItem");
import FlightItem = Item.FlightItem;

export class RouteItem {
   
    public id: number;
    public departurePlace: string;
    public destinationPlace: string;
    public arrivalTime: string;
    public departureTime: string;
    public flights: Array<FlightItem>;
    public totalCost: any;
    public totalTime: any;

    constructor(id: number, departurePlace: string, destinationPlace: string, arrivalTime: string, departureTime: string, flights: Array<FlightItem>, totalCost: any, totalTime: any) {
        this.totalTime = totalTime;
        this.totalCost = totalCost;
        this.flights = flights;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime;
        this.destinationPlace = destinationPlace;
        this.departurePlace = departurePlace;
        this.id = id;

    }
}