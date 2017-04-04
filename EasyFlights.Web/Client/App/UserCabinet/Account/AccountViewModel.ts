import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";
import ChangePasswordModel = require("./ChangePasswordModel");
require("knockout.validation");

class AccountViewModel {
    public isPasswordChanging: KnockoutObservable<boolean>;
    public isPasswordChanged: KnockoutObservable<boolean>;
    public email: KnockoutObservable<string>;
    public oldPassword: KnockoutObservable<string>;
    public newPassword: KnockoutObservable<string>;
    public newPasswordConfirm: KnockoutObservable<string>;
    private dataService:DataService = new DataService();
    private validateEmailUrl: string = "api/Cabinet/ValidateEmail?email=";
    private changePasswordUrl: string = "api/Cabinet/ChangePassword";
    private isEmailValid: KnockoutObservable<boolean>;

    public constructor() {
        this.isPasswordChanging = ko.observable(false);
        this.isPasswordChanged = ko.observable(false);
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
        this.email = ko.observable("").extend({
            required: true,
            email: true
        });

        this.newPasswordConfirm = ko.observable("").extend({
            required: true,
            areSame: {
                params: self.newPassword,
                message: "New pasword is not confirmed"
            }
        });
    }
    public validateEmail(): void {
        this.isEmailValid = ko.observable(false);
        if (this.email.isValid()) {
            this.dataService.get<boolean>(this.validateEmailUrl.concat(this.email()))
                .then((data) => {
                    this.isEmailValid(data);
                    if (this.isEmailValid()) {
                        this.isPasswordChanging(true);
                    }
                });
        } else {
            this.email.error();
        } 
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
                        this.isPasswordChanging(false);
                        this.isPasswordChanged(true);
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