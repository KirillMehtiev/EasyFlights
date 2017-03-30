import { PassengerInfoItem } from "./PassengerInfoItem";
import { IPassengerInfoOptions } from "./IPassengerInfoOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";

class AgeType {
    static adult = "Adult";
    static child = "Child";
}

class SexType {
    static male = "Male";
    static female = "Female";
}

class PassengerInfoViewModel {
    private passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    private ageOptions: Array<RadioChooserItem>;
    private sexOptions: Array<RadioChooserItem>;

    constructor(options: IPassengerInfoOptions) {
        this.passengerInfoList = options.passangerInfoList;
        this.ageOptions = [
            new RadioChooserItem("Adult (18 years and more)", AgeType.adult),
            new RadioChooserItem("Child (Under 18 years)", AgeType.child)
        ];
        this.sexOptions = [
            new RadioChooserItem(SexType.male, SexType.male),
            new RadioChooserItem(SexType.female, SexType.female)
        ];
    }
}

export = PassengerInfoViewModel;