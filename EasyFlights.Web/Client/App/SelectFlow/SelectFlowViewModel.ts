import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;

    // Internal routing
    public  isShowPassengerInfo: KnockoutObservable<boolean>;
    public isShowTicketInfo: KnockoutObservable<boolean>;
    public isShowOrderSummary: KnockoutObservable<boolean>;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
        this.passengerInfoList = ko.observableArray(this.initPassengerInfoList(1));

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
}

export = SelectFlowViewModel;