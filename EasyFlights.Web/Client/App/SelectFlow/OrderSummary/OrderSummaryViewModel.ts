import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { StepFlow } from "../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

class OrderSummaryViewModel {

    public passengers: KnockoutObservableArray<IEditablePassengerOptions>;

    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: IOrderSummaryOptions) {
        this.passengers = options.passengers;

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.OrderSummary);
    }
}

export = OrderSummaryViewModel;