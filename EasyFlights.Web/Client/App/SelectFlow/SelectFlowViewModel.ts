import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"
import {FlightItem} from "../SearchResults/FlightResults/Tickets/FlightItem";
import {DataService} from "../Common/Services/dataService";

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<FlightItem>;
    private dataService: DataService = new DataService();

    // Internal routing
    public isShowPassengerInfo: KnockoutObservable<boolean>;
    public isShowTicketInfo: KnockoutObservable<boolean>;
    public isShowOrderSummary: KnockoutObservable<boolean>;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
        this.passengerInfoList = ko.observableArray(this.initPassengerInfoList(this.numberOfPassenger()));
        this.fillFlightsList(this.routeId());

        // Flow routing
        this.isShowPassengerInfo = ko.observable(true);
        this.isShowTicketInfo = ko.observable(false);
        this.isShowOrderSummary = ko.observable(false);
    }

    private initPassengerInfoList(numberOfPassenger: number): Array<PassengerInfoItem> {
        let result = [];

        for (var i = 0; i < numberOfPassenger; i++) {
            result.push(new PassengerInfoItem());
        }

        return result;
    }

    public showTicketInfo(parent) {
        this.isShowPassengerInfo(false);
        this.isShowTicketInfo(true);
        this.isShowOrderSummary(false);
    }

    public showPassengerInfo(parent) {
        this.isShowPassengerInfo(true);
        this.isShowTicketInfo(false);
        this.isShowOrderSummary(false);
    }

    public showOrderSummary(parent) {
        this.isShowTicketInfo(false);
        this.isShowOrderSummary(true);
    }

    private fillFlightsList(routeId: string): void {
             this.dataService.get<Array<FlightItem>>("api/Flights/Get/".concat(routeId))
            .then((data) => this.flights(data));
    }
}

export = SelectFlowViewModel;