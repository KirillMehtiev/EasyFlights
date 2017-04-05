import ko = require("knockout");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { Sex } from "../../Common/Enum/Enums";
import ProfileInfoOptions = require("./IProfileInfoOptions");

class ProfileInfoViewModel {
    private options: Array<RadioChooserItem>;
   
    private sexOptions: Array<RadioChooserItem>;
    public isFemaleSelected: KnockoutObservable<boolean>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;
   

    constructor(options: ProfileInfoOptions.IProfileInfoOptions) {
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male.toString()),
            new RadioChooserItem("Female", Sex.Female.toString())
        ];
        

        }
    }
   

export = ProfileInfoViewModel;