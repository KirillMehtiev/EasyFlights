import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"
import { FlightItem } from "../SearchResults/FlightResults/Tickets/FlightItem";
import { SelectFlowService } from "./Services/SelectFlowService";
import { TicketInfoItem } from "./TicketInfo/TicketInfoItem";
import { StepFlow } from "../Common/Enum/Enums";

class SelectFlowViewModel {
    // Params
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;

    // Shared data
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<FlightItem>;
    private selectFlowServices: SelectFlowService = new SelectFlowService();

    // Internal routing
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;

    public isShowPassengerInfo: KnockoutObservable<boolean>;
    public isShowTicketInfo: KnockoutObservable<boolean>;
    public isShowOrderSummary: KnockoutObservable<boolean>;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
        this.passengerInfoList = ko.observableArray([]);
        this.flights = ko.observableArray([]);

        // Call api


        // Flow routing
        this.onNextStep = new ko.subscribable();
        this.onPreviousStep = new ko.subscribable();

        this.onNextStep.subscribe(this.nextStep, this);
        this.onPreviousStep.subscribe(this.previousStep, this);

        this.isShowPassengerInfo = ko.observable(true);
        this.isShowTicketInfo = ko.observable(false);
        this.isShowOrderSummary = ko.observable(false);

        // Update data
        this.isShowPassengerInfo.subscribe(this.updateTicketInfoData, this);
    }

    public nextStep(caller: number) {
        switch (caller) {
            case StepFlow.PassengerInformation:
                this.showTicketInfo();
                break;
            case StepFlow.TicketInformation:
                this.showOrderSummary();
                break;
            default:
                this.showPassengerInfo();
        }
    }

    public previousStep(caller: number) {
        console.log(caller);
        switch (caller) {
            case StepFlow.OrderSummary:
                this.showTicketInfo();
                break;
            case StepFlow.TicketInformation:
                this.showPassengerInfo();
                break;
            default:
                this.showPassengerInfo();
        }
    }

    private showTicketInfo() {
        this.isShowPassengerInfo(false);
        this.isShowTicketInfo(true);
        this.isShowOrderSummary(false);
    }

    private showPassengerInfo() {
        this.isShowPassengerInfo(true);
        this.isShowTicketInfo(false);
        this.isShowOrderSummary(false);
    }

    private showOrderSummary() {
        this.isShowTicketInfo(false);
        this.isShowOrderSummary(true);
    }

    private updateTicketInfoData(isShowTicketInfo: boolean) {
        if (isShowTicketInfo) {
            
        }
    }

    private getPassengerInfo(routeId:number, numberOfPassenger: number): Array<PassengerInfoDto> {
        let url: "";
    }
}

export = SelectFlowViewModel;