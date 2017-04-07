import ko = require("knockout");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { Sex } from "../../Common/Enum/Enums";
import Service = require("../../Common/Services/dataService");

import Item = require("../UserItem");
import UserOptions = require("../IUserOptions");
import UserItem = Item.UserItem;

class ProfileInfoViewModel {
    private options: Array<RadioChooserItem>;

    private sexOptions: Array<RadioChooserItem>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;
    public isDataChanged: KnockoutObservable<boolean>;
    private dataService: Service.DataService = new Service.DataService();
    public item: KnockoutObservable<Item.UserItem>;
    private getUrl: string = "api/Account/ChangeUser";


    constructor(params) {
        this.isDataChanged = ko.observable(false);
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male.toString()),
            new RadioChooserItem("Female", Sex.Female.toString())
        ];
        this.selectedBirthday = ko.observable("");
        this.birthdayDateName = ko.observable("birthdayDate");
        this.item = params.item;

        
    }
   
    public changeData(): boolean {
        let result: boolean = false;
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
        this.isDataChanged(true);
        if (viewModel.isValid()) {
            this.dataService.post<boolean>(this.getUrl,
                new UserItem(this.item().firstName, this.item().lastName, this.item().birthday, this.item().sex, this.item().contactPhone, this.item().email))

                .then((data) => {
                    result = data;
                   
                    if (result) {
                       
                        //this.isDataChanged(true);
                    }
                });
            return result;
        } else {
            viewModel.errors.showAllMessages();
            return false;
        }
    }
}

export = ProfileInfoViewModel;