import { PassengerInfoItem } from "./PassengerInfoItem";
import { IPassengerInfoOptions } from "./IPassengerInfoOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";

class AgeType {
    static adult = "Adult";
    static child = "Child";
}

class PassengerInfoViewModel {
    private passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    private ageOptions: Array<RadioChooserItem>;

    constructor(options: IPassengerInfoOptions) {
        this.passengerInfoList = options.passangerInfoList;
        this.ageOptions = [
            new RadioChooserItem("Adult (18 years and more)", "Adult"),
            new RadioChooserItem("Child (Under 18 years)", "Child")
        ];
    }
}

export = PassengerInfoViewModel;