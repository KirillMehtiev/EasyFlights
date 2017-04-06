import ko = require("knockout");
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { StepFlow } from "../../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

class OrderSummaryViewModel {

    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    public totalPrice: KnockoutComputed<number>;

    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: IOrderSummaryOptions) {
        this.passengerInfoList = options.passengerInfoList;

        this.totalPrice = ko.computed(() => this.computeTotalPrice());

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.OrderSummary);
    }

    private computeTotalPrice(): number {
        let totalPrice = 0;
        for (let i = 0; i < this.passengerInfoList().length; i++) {
            let passenger = this.passengerInfoList()[i];
            for (let j = 0; j < passenger.tickets().length; j++) {
                let ticket = passenger.tickets()[j];
                totalPrice += parseFloat(ticket.fare());
            }
        }
        return totalPrice;
    }
}

export = OrderSummaryViewModel;