import { StepFlow, Sex } from "../../../Common/Enum/Enums";
import { IEditablePassengerOptions } from "./IEditablePassengerOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";

class EditablePassengerViewModel {

    private static currentRadioChooserIndex: number = 0;

    private sexOptions: Array<RadioChooserItem>;

    public firstName: KnockoutObservable< string>;
    public lastName: KnockoutObservable<string>;
    public birthday: KnockoutObservable<string>;
    public documentNumber: KnockoutObservable<string>;
    public sex: KnockoutObservable<Sex>;

    public radioChooserIndex: number;

    constructor(options: IEditablePassengerOptions) {
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male.toString()),
            new RadioChooserItem("Female", Sex.Female.toString())
        ];

        this.firstName = options.firstName;
        this.lastName = options.lastName;
        this.birthday = options.birthday;
        this.documentNumber = options.documentNumber;
        this.sex = options.sex;

        this.radioChooserIndex = ++EditablePassengerViewModel.currentRadioChooserIndex;
    }
}

export = EditablePassengerViewModel;