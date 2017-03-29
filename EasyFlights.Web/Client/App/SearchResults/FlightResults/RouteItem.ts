import ko = require("knockout");
import Item = require("./Tickets/FlightItem");
import FlightItem = Item.FlightItem;

export class RouteItem {

    public arrivalTime: string;
    //public id: number;
    public departurePlace: string;
    public departureTime: string;
    public destinationPlace: string;
   
   
    public flights: Array<FlightItem>;
    public totalCoast: any;
    public totalTime: any;
   

    constructor( departurePlace: string, destinationPlace: string, arrivalTime: string, departureTime: string, flights: Array<FlightItem>, totalCost: any, totalTime: any) {
        this.totalTime = totalTime;
        this.totalCoast = totalCost;
        this.flights = flights;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime;
        this.destinationPlace = destinationPlace;
        this.departurePlace = departurePlace;
        //this.id = id;

    }
}