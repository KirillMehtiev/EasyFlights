import { PassengerInfoItem } from "./PassengerInfoItem";
import { IPassengerInfoOptions } from "./IPassengerInfoOptions";

class PassengerInfoViewModel {
    private passengerInfoList: Array<PassengerInfoItem>;

    constructor(options: IPassengerInfoOptions) {
        this.passengerInfoList = options.passangerInfoList;
    }
}

export = PassengerInfoViewModel;