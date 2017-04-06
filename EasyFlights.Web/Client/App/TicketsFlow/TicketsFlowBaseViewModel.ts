import ko = require("knockout");
import moment = require("moment");

import { StepFlow } from "../Common/Enum/Enums";
import { SelectFlowService } from "./Services/SelectFlowService";
import { IEditablePassengerOptions } from "./BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "./BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";
import { EditablePassengerOptions } from "./EditablePassengerOptions";
import { EditableTicketOptions } from "./EditableTicketOptions";

abstract class TicketsFlowBaseViewModel {
    // Params
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;

    // Shared data
    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;

    protected selectFlowServices: SelectFlowService = new SelectFlowService();

    // Internal routing
    public onNextStep: KnockoutSubscribable<number>;
    public onPreviousStep: KnockoutSubscribable<number>;

    public isShowPassengerInfo: KnockoutObservable<boolean>;
    public isShowTicketInfo: KnockoutObservable<boolean>;
    public isShowOrderSummary: KnockoutObservable<boolean>;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;

        this.initPassengerInfoList(this.routeId(), this.numberOfPassenger());
        this.extendEditablePassengerWithValidation(this.passengerInfoList);

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
        if (!this.validatePassengersInfo()) return;
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
    }

    

    private extendEditablePassengerWithValidation(passengers: KnockoutObservableArray<IEditablePassengerOptions>) {
        for (let i = 0; i < passengers().length; i++) {
            let passenger = passengers()[i];

            passenger.firstName.extend({
                required: true
            });
            passenger.lastName.extend({
                required: true
            });
            passenger.birthday.extend({
                required: true,
                dateBefore: moment().format("L")
            });
            passenger.documentNumber.extend({
                required: true
            });
        }
    }

    private validatePassengersInfo() {
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable({
            passengers: this.passengerInfoList
        });

        if (!viewModel.isValid()) {
            viewModel.errors.showAllMessages();
            return false;
        }

        return true;
    }
    // an example of an abstract method
    //abstract makeSound(): void;

    protected abstract initPassengerInfoList(routeId: string, numberOfPassenger: number);

}

export = TicketsFlowBaseViewModel;