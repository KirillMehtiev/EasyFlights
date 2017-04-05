import ko = require("knockout");
import { TicketInfoItem } from "../TicketInfo/TicketInfoItem";
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { ITicketInfoItemOptions } from "../TicketInfo/ITicketInfoItemOptions";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"
import { StepFlow } from "../../Common/Enum/Enums";

class OrderSummaryViewModel {

    public tickets: KnockoutObservableArray<{}>;
    public flights: KnockoutObservableArray<RouteItem>;
    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: ITicketInfoItemOptions) {
        //this.tickets = options.passengers;
        //this.flights = options.flights;

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.OrderSummary);
    }
}

export = OrderSummaryViewModel;