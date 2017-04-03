﻿import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";
import ChangePasswordModel = require("./ChangePasswordModel");
class AccountViewModel {
    public isPasswordChanging: KnockoutObservable<boolean>;
    public email: KnockoutObservable<string>;
    public oldPassword: KnockoutObservable<string>;
    public newPassword: KnockoutObservable<string>;
    public newPasswordConfirm: KnockoutObservable<string>;
    private dataService:DataService = new DataService();
    private validateEmailUrl: string = "api/Cabinet/ValidateEmail?email=";
    private changePasswordUrl: string = "api/Cabinet/ChangePassword";

    public constructor() {
        this.isPasswordChanging = ko.observable(false);
        this.oldPassword = ko.observable("");
        this.newPassword = ko.observable("");
        this.newPasswordConfirm = ko.observable("");
        this.email = ko.observable("");
    }
    public validateEmail(): void {
        let isEmailValid: boolean = false;
        this.dataService.get<boolean>(this.validateEmailUrl.concat(this.email()))
            .then((data) => { isEmailValid=data });
        if (isEmailValid) {
            this.isPasswordChanging = ko.observable(true);
        }
    }
    public changePassword():boolean {
        let result: boolean = false;
        this.dataService.post<boolean>(this.changePasswordUrl,new ChangePasswordModel(this.oldPassword(),this.newPassword(),this.newPasswordConfirm()))
            .then((data) => { result = data });
        if (result) {
            this.oldPassword = ko.observable("");
            this.newPassword = ko.observable("");
            this.newPasswordConfirm = ko.observable("");
        }
        return result;
    }
}

export = AccountViewModel;