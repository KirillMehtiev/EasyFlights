import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";
import ChangePasswordModel = require("./ChangePasswordModel");
require("knockout.validation");

class AccountViewModel {
    public email: KnockoutObservable<string>;
    public oldPassword: KnockoutObservable<string>;
    public newPassword: KnockoutObservable<string>;
    public newPasswordConfirm: KnockoutObservable<string>;
    private dataService:DataService = new DataService();
    private getEmailUrl: string = "api/Cabinet/GetEmail";
    private changePasswordUrl: string = "api/Cabinet/ChangePassword";

    public constructor() {
        let self = this;
        this.oldPassword = ko.observable("").extend({
            required: true,
            password: {
                params: {
                    minLength: 6,
                    maxLenght: 50,
                    shouldContainAtLeastOneDigit: true,
                    shouldContainAtLeastOneCapitalLetter: true
                },
                message: "A password should contain at least one digit and one capital letter. " +
                "The length of a password should be greater than 6 characters and less than 50 characters"
            }
        });
        this.newPassword = ko.observable("").extend({
            required: true,
            password: {
                params: {
                    minLength: 6,
                    maxLenght: 50,
                    shouldContainAtLeastOneDigit: true,
                    shouldContainAtLeastOneCapitalLetter: true
                },
                message: "A password should contain at least one digit and one capital letter. " +
                "The length of a password should be greater than 6 characters and less than 50 characters"
            },
            areNotSame: {
                params: self.oldPassword,
                message: "New password must not be the same as old one"
            }
        });
        this.email = ko.observable("");

        this.newPasswordConfirm = ko.observable("").extend({
            required: true,
            areSame: {
                params: self.newPassword,
                message: "New pasword is not confirmed"
            }
        });
        this.getEmail();
    }
    public getEmail(): void {
        this.dataService.get(this.getEmailUrl)
            .then((data:string)=> { this.email(data); });
    }
    public changePassword():boolean {
        let result: boolean = false;
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.dataService.post<boolean>(this.changePasswordUrl,
                    new ChangePasswordModel(this.oldPassword(), this.newPassword(), this.newPasswordConfirm()))
                .then((data) => {
                    result = data;
                    if (result) {
                        this.email("");
                        this.oldPassword("");
                        this.newPassword("");
                        this.newPasswordConfirm("");
                    }
                });
            return result;
        } else {
            viewModel.errors.showAllMessages();
            return false;
        }
    }
}

export = AccountViewModel;