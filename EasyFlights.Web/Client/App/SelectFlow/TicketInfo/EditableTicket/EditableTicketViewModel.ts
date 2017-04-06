﻿import { TicketClass } from "../../../Common/Enum/Enums";
import { IEditableTicketOptions } from "./IEditableTicketOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";

class EditableTicketViewModel {
    public seat: KnockoutObservable<number>;
    public departureAirport: KnockoutObservable<string>;
    public destinationAirport: KnockoutObservable<string>;
    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;

    constructor(options: IEditableTicketOptions) {
        this.seat = options.seat;
        this.departureAirport = options.departureAirport;
        this.destinationAirport = options.destinationAirport;
        this.firstName = options.firstName;
        this.lastName = options.lastName;
    }
}

export = EditableTicketViewModel;