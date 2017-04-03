import { PassengerInfoItem } from "./PassengerInfoItem";
import { IPassengerInfoOptions } from "./IPassengerInfoOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { StepFlow, SexType } from "../../Common/Enum/Enums";

class PassengerInfoViewModel {
    private passengerInfoList: KnockoutObservableArray<PassengerInfoItem>;
    private sexOptions: Array<RadioChooserItem>;
    private onNextStep: KnockoutSubscribable<number>;

    constructor(options: IPassengerInfoOptions) {
        this.passengerInfoList = options.passangerInfoList;
        this.sexOptions = [
            new RadioChooserItem("Male", SexType.Male.toString()),
            new RadioChooserItem("Female", SexType.Female.toString())
        ];
        this.onNextStep = options.onNextStep;
        this.nextStep.bind(this);
    }

    public nextStep() {
        this.onNextStep.notifySubscribers(StepFlow.PassengerInformation);
    }
}

export = PassengerInfoViewModel;