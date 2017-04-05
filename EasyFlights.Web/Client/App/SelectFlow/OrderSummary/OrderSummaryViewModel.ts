import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { StepFlow } from "../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

class OrderSummaryViewModel {

    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;

    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: IOrderSummaryOptions) {
        this.passengerInfoList = options.passengerInfoList;

        console.log(this.passengerInfoList());

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.OrderSummary);
    }
}

export = OrderSummaryViewModel;