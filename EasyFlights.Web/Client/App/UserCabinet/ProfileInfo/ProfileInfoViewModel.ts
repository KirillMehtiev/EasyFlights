import ko = require("knockout");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { Sex } from "../../Common/Enum/Enums";
import ProfileInfoOptions = require("./IProfileInfoOptions");
import Service = require("../../Common/Services/dataService");
import InfoItem = require("./ProfileInfoItem");

class ProfileInfoViewModel {
    private options: Array<RadioChooserItem>;
   
    private sexOptions: Array<RadioChooserItem>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;
    public isDataChanged: KnockoutObservable<boolean>;
    private dataService: Service.DataService = new Service.DataService();
    public item: InfoItem.ProfileInfoItem;

   

    constructor(options: ProfileInfoOptions.IProfileInfoOptions) {
        this.isDataChanged = ko.observable(false);
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male.toString()),
            new RadioChooserItem("Female", Sex.Female.toString())
        ];
        this.selectedBirthday = ko.observable("");
        this.birthdayDateName = ko.observable("birthdayDate");
        this.item = options.profileInfo;


    }

    }
   

export = ProfileInfoViewModel;