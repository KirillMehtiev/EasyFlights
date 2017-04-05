import ko = require("knockout");
import { FlightItem } from "../SearchResults/FlightResults/Tickets/FlightItem";
import { PassengerInfoDto } from "../Common/Dtos/PassengerInfoDto";
import { SelectFlowService } from "./Services/SelectFlowService";
import { TicketInfoItem } from "./TicketInfo/TicketInfoItem";
import { StepFlow } from "../Common/Enum/Enums";
import { IEditablePassengerOptions } from "./PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "./TicketInfo/EditableTicket/IEditableTicketOptions";
import { EditablePassengerOptions } from "./EditablePassengerOptions";
import { EditableTicketOptions } from "./EditableTicketOptions";

class SelectFlowViewModel {
    // Params
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;

    // Shared data
    public passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
    //public generalTicketInfo: KnockoutObservableArray<TicketInfoGeneral>;
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

        //this.generalTicketInfo = ko.observableArray([]);

        this.initPassengerInfoList(this.routeId(), this.numberOfPassenger());

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
        //if (!isShowTicketInfo) {
        //    console.log("Ticket Triggered");
        //    let url = "GetTickets";
        //    this.selectFlowServices.getTicketInfo(url, this.routeId(), this.passengerInfoList()).then((data) => {
        //        this.generalTicketInfo(data);
        //    });
        //}
    }

    private initPassengerInfoList(routeId: string, numberOfPassenger: number) {
        this.passengerInfoList = ko.observableArray([]);
        for (let i = 0; i < numberOfPassenger; i++) {
            this.passengerInfoList.push(new EditablePassengerOptions());
        }

        this.selectFlowServices
            .loadRoute(this.routeId())
            .then((route => {
                for (let i = 0; i < this.passengerInfoList().length; i++) {
                    let passenger = this.passengerInfoList()[i];
                    passenger.tickets = this.createTicketsForPassenger(route.flights);
                }
            }));
    }

    private createTicketsForPassenger(flights: Array<any>): KnockoutObservableArray<IEditableTicketOptions> {
        let result = ko.observableArray([]);
        for (let i = 0; i < flights.length; i++) {
            let flight = flights[i];
            let ticket = new EditableTicketOptions();

            ticket.departureAirport(flight.departureAirport);
            ticket.destinationAirport(flight.destinationAirport);
            ticket.duration(flight.duration);
            ticket.fare(flight.fare);
            ticket.departureTime(flight.departureTime);

            result.push(ticket);
        }
        return result;
    }
}

export = SelectFlowViewModel;