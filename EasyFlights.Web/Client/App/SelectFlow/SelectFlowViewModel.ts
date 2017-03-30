import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"
import {FlightItem} from "../SearchResults/FlightResults/Tickets/FlightItem";

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    public flights:KnockoutObservableArray<FlightItem>;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
        this.passengerInfoList = ko.observableArray(this.initPassengerInfoList(1));
        this.flights = params.flights;
    }

    private initPassengerInfoList(numberOfPassenger: number): Array<PassengerInfoItem> {
        let result = [];

        for (var i = 0; i < numberOfPassenger; i++) {
            result.push(new PassengerInfoItem());
        }

        return result;
    }
}

export = SelectFlowViewModel;