import { TicketInfoItem } from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"

class TicketInfoViewModel {
    public tickets: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<RouteItem>;

    constructor(options: ITicketInfoItemOptions) {
        this.tickets = options.passengers;
        this.flights = options.flights;

    }
}
export = TicketInfoViewModel;