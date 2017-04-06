import ko = require("knockout");
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";
import { TicketInfoItem } from "./TicketInfoItem";


export class FlightItem {
    //public id: number;
    public arrivalTime: string;
    public departureAirport: string;
    public departureTime: string;
    public destinationAirport: string;    
    public duration: string;
    public fare: string;
    public tickets: KnockoutObservableArray<TicketInfoItem>;
    public aircraft: string;
    public country: string;
    public classTypes: Array<RadioChooserItem>;


    constructor(id: number, departureAirport: string, destinationAirport: string, departureTime: string,
        arrivalTime: string, duration: string, fare: string, tickets: KnockoutObservableArray<TicketInfoItem>, aircraft: string, country: string) {
        this.country = country;
        this.aircraft = aircraft;
        //this.id = id;
        this.departureAirport = departureAirport;
        this.destinationAirport = destinationAirport;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime; 
        this.duration = duration;
        this.fare = fare;
        this.tickets = tickets;
        this.classTypes = [
            new RadioChooserItem("Economy", "Economy"),
            new RadioChooserItem("Business", "Business"),
            new RadioChooserItem("First", "First")
        ];
    }
}