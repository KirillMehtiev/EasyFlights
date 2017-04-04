import ko = require("knockout");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";

class ProfileInfoViewModel {
    private options: Array<RadioChooserItem>;
    public selectedSexType: KnockoutObservable<string>;
    public isFemaleSelected: KnockoutObservable<boolean>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;
   

    constructor() {
        this.options = [
            new RadioChooserItem("Male", "Male"),
            new RadioChooserItem("Female", "Female")
        ];
        this.selectedSexType = ko.observable("Male");
        this.isFemaleSelected = ko.observable(false);
        this.selectedSexType.subscribe(this.onSexChanged, this);

        this.birthdayDateName = ko.observable("birthdayDate");
        this.selectedBirthday = ko.observable("");
    }
    public onSexChanged(newValue: string) {
        this.isFemaleSelected(newValue === "Female");

        }
    }
   

export = ProfileInfoViewModel;