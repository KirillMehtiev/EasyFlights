import ko = require("knockout");
import { IOrderSummaryOptions } from "./IOrderSummaryOptions";
import { StepFlow } from "../../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { AuthService } from "../../Common/Services/Auth/authService";
import { DataService } from "../../Common/Services/dataService";

class OrderSummaryViewModel {

    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    public totalPrice: KnockoutComputed<number>;

    public onPreviousStep: KnockoutSubscribable<number>;

    public isRequestProcessing: KnockoutObservable<boolean>;
    public dataService: DataService = new DataService();
    private urlToBookTickets: string = "api/Tickets/BookTickets";

    constructor(options: IOrderSummaryOptions) {
        this.passengerInfoList = options.passengerInfoList;

        this.totalPrice = ko.computed(() => this.computeTotalPrice());

        this.onPreviousStep = options.onPreviousStep;
        this.previousStep.bind(this);
        this.isRequestProcessing = ko.observable(false);
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

    public bookTickets() {
        var data = {
            tickets: [{
                passenger: {
                    firstName: "Dima",
                    lastName: "Hrihoryev",
                    birthday: "01.02.2017",
                    documentNumber: "MT1488"
                },
                flightClass: 0,
                seat: {
                    isBooked: false,
                    number: 31
                },
                price: 228,
                ticketNumber: 322
            }]
        };

        if (AuthService.current.isCurrentUserSignedIn() === false) {
            window.localStorage.setItem("filledData", JSON.stringify(data));
            window.location.href = "#sign-in";
            return;
        }

        this.isRequestProcessing(true);
        this.dataService.post(this.urlToBookTickets, data)
            .then(() => {
                window.localStorage.removeItem("filledData");
                window.location.href = "#userCabinet";
            }).always(() => this.isRequestProcessing(false));
    }
}

export = OrderSummaryViewModel;