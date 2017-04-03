import { TicketInfoItem } from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"
import { StepFlow } from "../../Common/Enum/Enums";

class TicketInfoViewModel {
    public tickets: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<RouteItem>;
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: ITicketInfoItemOptions) {
        this.tickets = options.passengers;
        this.flights = options.flights;
        this.onNextStep = options.onNextStep;
        this.onPreviousStep = options.onPreviousStep;

        this.nextStep.bind(this);
        this.previousStep.bind(this);
    }

    public nextStep() {
        this.onNextStep.notifySubscribers(StepFlow.TicketInformation);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.TicketInformation);
    }
    
}
export = TicketInfoViewModel;