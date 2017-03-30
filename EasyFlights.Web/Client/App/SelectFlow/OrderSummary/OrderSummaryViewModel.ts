import ko = require("knockout");
import { TicketInfoItem } from "../TicketInfo/TicketInfoItem";
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";

class OrderSummaryViewModel {

    public ticket: KnockoutObservableArray<IOrderSummaryOptions>;

    constructor(options: IOrderSummaryOptions) {
    }
}

export = OrderSummaryViewModel;