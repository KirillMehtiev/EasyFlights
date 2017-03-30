import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"
import {FlightItem} from "../SearchResults/FlightResults/Tickets/FlightItem";
import {DataService} from "../Common/Services/dataService";

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    public flights: KnockoutObservableArray<FlightItem>;
    private dataService: DataService;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
        this.passengerInfoList = ko.observableArray(this.initPassengerInfoList(1));
        this.fillFlightsList(params.routeId);
    }

    private initPassengerInfoList(numberOfPassenger: number): Array<PassengerInfoItem> {
        let result = [];

        for (var i = 0; i < numberOfPassenger; i++) {
            result.push(new PassengerInfoItem());
        }

        return result;
    }
    private fillFlightsList(routeId: string): void {
             this.dataService.get<Array<FlightItem>>("api/Flights/Get/".concat(routeId))
            .then((data) => this.flights(data));       
    }
}

export = SelectFlowViewModel;