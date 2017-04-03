import { TicketInfoItem } from "../TicketInfo/TicketInfoItem";

export interface IOrderSummaryOptions {
    items: KnockoutObservableArray<TicketInfoItem>;
    onPreviousStep: KnockoutSubscribable<number>;
}