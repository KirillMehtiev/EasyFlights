import { IPassengerInfoItem } from "./IPassengerInfoItem";
import { IPassengerInfoOptions } from "./IPassengerInfoOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { StepFlow, Sex } from "../../Common/Enum/Enums";

class PassengerInfoViewModel {
    private passengerInfoList: KnockoutObservableArray<IPassengerInfoItem>;
    private sexOptions: Array<RadioChooserItem>;
    private onNextStep: KnockoutSubscribable<number>;

    constructor(options: IPassengerInfoOptions) {
        this.passengerInfoList = options.passangerInfoList;
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male.toString()),
            new RadioChooserItem("Female", Sex.Female.toString())
        ];
        this.onNextStep = options.onNextStep;
        this.nextStep.bind(this);
    }

    public nextStep() {
        this.onNextStep.notifySubscribers(StepFlow.PassengerInformation);
    }
}

export = PassengerInfoViewModel;