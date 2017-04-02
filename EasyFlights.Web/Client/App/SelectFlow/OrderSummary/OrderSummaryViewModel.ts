import ko = require("knockout");
import { TicketInfoItem } from "../TicketInfo/TicketInfoItem";
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { ITicketInfoItemOptions } from "../TicketInfo/ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"
class OrderSummaryViewModel {

    public tickets: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<RouteItem>;

    constructor(options: ITicketInfoItemOptions) {
        this.tickets = options.passengers;
        this.flights = options.flights;

    }
}

export = OrderSummaryViewModel;