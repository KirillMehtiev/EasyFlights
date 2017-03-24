import ko = require("knockout");

export class TicketItem {
    public id: number;
    public flight:string;
    public country: string;
    public flightType: string;
    public departure: string;
    public cityDeparture: string;
    public duration: string;
    public arrival: string;
    public cityArrival: string;
    public fare: string;

    constructor(id: number, flight: string, country: string, flightType: string, departure: string, cityDeparture: string, duration: string, arrival: string, cityArrival: string, fare:string) {
        this.id = id;
        this.flight =flight;
        this.country = country;
        this.flightType = flightType;
        this.departure = departure;
        this.cityDeparture = cityDeparture;
        this.duration = duration;
        this.arrival = arrival;
        this.cityArrival = cityArrival;
        this.fare = fare;
    }
}