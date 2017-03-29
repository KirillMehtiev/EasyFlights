import ko = require("knockout");
import { PassengerInfoItem } from "./PassengerInfo/PassengerInfoItem"

class SelectFlowViewModel {
    public routeId: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public passengerInfoList: Array<PassengerInfoItem>;

    constructor(params) {
        //this.initPassengerInfoList(this.numberOfPassenger());
        this.passengerInfoList = this.initPassengerInfoList(1);
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