import { TicketInfoItem } from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { RouteItem } from "../../SearchResults/FlightResults/RouteItem"
import { StepFlow } from "../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "./EditableTicket/IEditableTicketOptions";

class TicketInfoViewModel {
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;
    public passengersInfoList: KnockoutObservableArray<IEditablePassengerOptions>;

    constructor(options: ITicketInfoItemOptions) {
        this.passengersInfoList = options.passengersInfoList;
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