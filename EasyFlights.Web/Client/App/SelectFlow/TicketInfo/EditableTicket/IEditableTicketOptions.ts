import { TicketClass } from "../../../Common/Enum/Enums";

export interface IEditableTicketOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    fare: KnockoutObservable<number>;
    seat: KnockoutObservable<string>;
    class: KnockoutObservable<TicketClass>;
}
