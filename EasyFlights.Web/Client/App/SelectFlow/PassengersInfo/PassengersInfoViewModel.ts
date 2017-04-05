import { IPassengersInfoOptions } from "./IPassengersInfoOptions";
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { StepFlow, Sex } from "../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "./EditablePassenger/IEditablePassengerOptions";

class PassengersInfoViewModel {
    public passengersInfoList: KnockoutObservableArray<IEditablePassengerOptions>;

    private onNextStep: KnockoutSubscribable<number>;

    constructor(options: IPassengersInfoOptions) {
        this.passengersInfoList = options.passengerInfoList;

        this.onNextStep = options.onNextStep;
        this.nextStep.bind(this);
    }

    public nextStep() {
        this.onNextStep.notifySubscribers(StepFlow.PassengerInformation);
    }
}

export = PassengersInfoViewModel;