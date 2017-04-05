import { TicketInfoItem } from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { IPassengerInfoItem } from "../PassengerInfo/IPassengerInfoItem";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"
import { StepFlow } from "../../Common/Enum/Enums";
import { TicketInfoGeneral } from "./TicketInfo";

class TicketInfoViewModel {
    public generalInfo: KnockoutObservableArray<TicketInfoGeneral>;
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: ITicketInfoItemOptions) {
        this.generalInfo = options.generalInfo;
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