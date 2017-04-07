import ko = require("knockout");
import { IEditableTicketOptions } from "./BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { TicketClass } from "../Common/Enum/Enums";


export class EditableTicketOptions implements IEditableTicketOptions {
    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;
    public departureAirport: KnockoutObservable<string>;
    public destinationAirport: KnockoutObservable<string>;
    public duration: KnockoutObservable<string>;
    public fare: KnockoutObservable<string>;
    public departureTime: KnockoutObservable<string>;
    public seat: KnockoutObservable<number>;
    public seatChosen: KnockoutObservableArray<number>;

    constructor() {
        this.departureAirport = ko.observable("");
        this.destinationAirport = ko.observable("");
        this.duration = ko.observable("");
        this.fare = ko.observable("");
        this.departureTime = ko.observable("");
        this.seat = ko.observable<number>();
    }
}
