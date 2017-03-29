import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;

    constructor(params) {
        // TODO: CHANGE 1 TO REAL NUMBER OF PEOPLE
        this.passengerInfoList = ko.observableArray(this.initPassengerInfoList(1));
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