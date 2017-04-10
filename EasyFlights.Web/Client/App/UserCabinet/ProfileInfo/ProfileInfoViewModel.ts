import ko = require("knockout");
import toastr = require("toastr");
import moment = require("moment");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { Sex } from "../../Common/Enum/Enums";
import Service = require("../../Common/Services/dataService");
import { ProfileItem } from "./ProfileItem";
import { ChangeUserItem } from "./ChangeUserItem"



class ProfileInfoViewModel {

    public item: KnockoutObservable<ProfileItem>;
    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;
    public contactPhone: KnockoutObservable<string>;
    public sexOptions: Array<RadioChooserItem>;
    public selectedSex: KnockoutObservable<Sex>;
    public selectedBirthday: KnockoutObservable<string>;
    public birthdayDateName: KnockoutObservable<string>;

    public isRequestProcessing: KnockoutObservable<boolean>;
    private dataService: Service.DataService = new Service.DataService();
    private changeUrl: string = "api/Account/ChangeUser";
    private getUrl: string = "api/Account/UserInfo";

    constructor() {
        this.selectedSex = ko.observable(Sex.Female);
        this.sexOptions = [
            new RadioChooserItem("Male", Sex.Male),
            new RadioChooserItem("Female", Sex.Female)
        ];

        this.item = ko.observable(new ProfileItem("", "", "", "", "", Sex.Female));
        this.isRequestProcessing = ko.observable(false);
        this.firstName = ko.observable("").extend({
            required: true,
            minLength: 1,
            maxLength: 50
        });
        this.lastName = ko.observable("").extend({
            required: true,
            minLength: 1,
            maxLength: 50
        });
        this.contactPhone = ko.observable("").extend({
            required: true,
            phoneUS: true
        });
        this.selectedBirthday = ko.observable("").extend({
            dateBefore: moment().format("L")
        });

        this.getUser();
        this.birthdayDateName = ko.observable("birthdayDate");
        this.changeData.bind(this);

        
    }
    private getUser() {
        this.isRequestProcessing(true);
        this.dataService.get<ProfileItem>(this.getUrl)
            .then((data) => {
                this.item(data);

                console.log(this.item());
                
                this.selectedBirthday(data.dateOfBirth);
                this.firstName(data.firstName);
                this.lastName(data.lastName);
                this.contactPhone(data.contactPhone);
                if (data.sex != null) {
                    this.selectedSex(Sex[(data.sex).toString()]);
                }
          
            }).always(() => this.isRequestProcessing(false));;
    } 

    private changeData() {
       
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.item().firstName = this.firstName();
            this.item().lastName = this.lastName();
            this.item().contactPhone = this.contactPhone();
            this.item().sex = this.selectedSex();
            this.dataService.post<boolean>(this.changeUrl,
                new ChangeUserItem(this.item().firstName, this.item().lastName, moment(this.selectedBirthday()).format('DD.MM.YYYY'), this.item().contactPhone, this.item().email, this.item().sex))
                .then((data) => {
                 
                    toastr.success("Information successfully updated!", "Succes");

                });
        } else {
            viewModel.errors.showAllMessages();
        }
    }
}
export = ProfileInfoViewModel;