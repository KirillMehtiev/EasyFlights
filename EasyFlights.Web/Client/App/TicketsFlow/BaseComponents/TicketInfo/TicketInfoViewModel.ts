import { ITicketInfoOptions } from "./ITicketInfoOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";
import { RouteItem } from "../../../SearchResults/FlightResults/RouteItem"
import { StepFlow } from "../../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "./EditableTicket/IEditableTicketOptions";

class TicketInfoViewModel {
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;
    public seatChosen: KnockoutObservableArray<number>;
    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;

    constructor(options: ITicketInfoOptions) {
        this.passengerInfoList = options.passengerInfoList;
        this.onNextStep = options.onNextStep;
        this.onPreviousStep = options.onPreviousStep;
        var amount = new Array();
        for (var i = 0; i < this.passengerInfoList().length; i++) {
            amount[this.passengerInfoList()[i].firstName()] = 0;
        }
        this.seatChosen = ko.observableArray<number>(amount);
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