import ko = require("knockout");
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { StepFlow } from "../../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

class OrderSummaryViewModel {
    private confirmCallback: Function;

    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    public totalPrice: KnockoutComputed<number>;

    public onPreviousStep: KnockoutSubscribable<number>;

    constructor(options: IOrderSummaryOptions) {
        this.passengerInfoList = options.passengerInfoList;
        this.confirmCallback = options.confirmCallback;

        this.totalPrice = ko.computed(() => this.computeTotalPrice());

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
    }

    public previousStep() {
        this.onPreviousStep.notifySubscribers(StepFlow.OrderSummary);
    }

    public confirm():void {
    swal({
        title: "Are you sure?",
        text: "Did you check your personal information?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, book tickets!",
        cancelButtonText: "No, check info!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        isConfirm => {
            if (isConfirm) {
                swal("Done!", "Your tickets were booked successfully", "success");
                this.confirmCallback();
            } else {
                swal("Cancelled", "Check your information and try again", "error");
            }
        });
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