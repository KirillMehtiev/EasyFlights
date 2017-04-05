import ko = require("knockout");
import { IEditableTicketOptions } from "./TicketInfo/EditableTicket/IEditableTicketOptions";
import { TicketClass } from "../Common/Enum/Enums";


export class EditableTicketOptions implements IEditableTicketOptions {
    public seat: KnockoutObservable<number>;

    constructor() {
        this.seat = ko.observable<number>();
    }
}