import ko = require("knockout");

export class FlightItem {
    public id: number;
   
    public departureAirport: string;
    public destinationAirport: string;
    public departureTime: string;
    public arrivalTime: string;
    public duration: string;
    public fare: string;

    constructor(id: number, departureAirport: string, destinationAirport: string, departureTime: string,  arrivalTime: string, duration: string, fare:string) {
        this.id = id;
        this.departureAirport = departureAirport;
        this.destinationAirport = destinationAirport;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime; 
        this.duration = duration;
        this.fare = fare;
    }
}