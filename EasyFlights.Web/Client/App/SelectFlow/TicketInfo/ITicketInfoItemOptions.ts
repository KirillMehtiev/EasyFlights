import { TicketInfoItem } from "./TicketInfoItem";
import { TicketInfoGeneral } from "./TicketInfo";

export interface ITicketInfoItemOptions {
    generalInfo: KnockoutObservableArray<TicketInfoGeneral>;
    onNextStep: KnockoutSubscribable<number>;
    onPreviousStep: KnockoutSubscribable<number>;
}