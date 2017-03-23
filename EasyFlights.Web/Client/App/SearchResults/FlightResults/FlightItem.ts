import ko = require("knockout");

export class FlightItem {
    public id: number;
    public flight: KnockoutObservable<string>;
    public country: KnockoutObservable<string>;
    public flightType: KnockoutObservable<string>;
    public departure: KnockoutObservable<string>;
    public duration: KnockoutObservable<string>;
    public arrival: KnockoutObservable<string>;
    public cityArrival: KnockoutObservable<string>;
    

    constructor(id: number, flight: string, country: string, flightType: string, departure: string, duration: string, arrival: string, cityArrival: string) {
        this.id = id;
        this.flight = ko.observable(flight);

        this.country = ko.observable(country);
        this.flightType = ko.observable(flightType);

        this.departure = ko.observable(departure);
        this.duration = ko.observable(duration);
        
        
        this.arrival = ko.observable(arrival);
        this.cityArrival = ko.observable(cityArrival);
        
  
        
    }
}