import ko = require("knockout");
import toastr = require("toastr");
import moment = require("moment");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { Sex } from "../../Common/Enum/Enums";
import Service = require("../../Common/Services/dataService");
import { ProfileItem } from "./ProfileItem";
import { ChangeUserItem } from "./ChangeUserItem"



class ProfileInfoViewModel {
    
    public sexOptions: Array<RadioChooserItem>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;
    public isRequestProcessing: KnockoutObservable<boolean>;
    public selectedSex:KnockoutObservable<string>;
    private dataService: Service.DataService = new Service.DataService();
    public item: KnockoutObservable<ProfileItem>;
    private changeUrl: string = "api/Account/ChangeUser";
    private getUrl: string = "api/Account/UserInfo";


    constructor() {
        this.selectedSex = ko.observable("");
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male),
            new RadioChooserItem("Female", Sex.Female)
        ];
        this.item = ko.observable(new ProfileItem("", "", "", "", "", ""));
        this.isRequestProcessing = ko.observable(false);
        this.selectedBirthday = ko.observable("");
        this.getUser();

        this.birthdayDateName = ko.observable("birthdayDate");
        this.changeData.bind(this);

        
    }
    private getUser() {
        this.isRequestProcessing(true);
        this.dataService.get<ProfileItem>(this.getUrl)
            .then((data) => {
                this.item(data);
                this.selectedSex(Sex[data.sex].toString());
                console.log(this.selectedSex());
                this.selectedBirthday(data.dateOfBirth);
            }).always(() => this.isRequestProcessing(false));;
           
      

    } 
    public changeData(): boolean {
        let result: boolean = false;
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
        //toastr.success("Information successfully updated!", "Succes");
        if (viewModel.isValid()) {
            this.item().sex = this.selectedSex();
            this.dataService.post<boolean>(this.changeUrl,
                new ChangeUserItem(this.item().firstName, this.item().lastName, moment(this.selectedBirthday()).format("L"), this.item().contactPhone, this.item().email, this.item().sex))
                .then((data) => {
                    result = data;
                    if (result) {
                        toastr.success("Information successfully updated!", "Succes");
                     
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