import ko = require("knockout");
import { IEditableTicketOptions } from "./TicketInfo/EditableTicket/IEditableTicketOptions";
import { TicketClass } from "../Common/Enum/Enums";


export class EditableTicketOptions implements IEditableTicketOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    fare: KnockoutObservable<number>;
    seat: KnockoutObservable<string>;
    class: KnockoutObservable<TicketClass>;

    constructor() {
        this.firstName = ko.observable("");
        this.lastName = ko.observable("");
        this.fare = ko.observable(0);
        this.seat = ko.observable("");
        this.class = ko.observable(TicketClass.Economy);
    }
}