import ko = require("knockout");
require("knockout.validation");

import { DataService } from "../Common/Services/DataService";

class SignUpViewModel {

    private dataService: DataService;

    public userName: KnockoutObservable<string>;
    public userSurname: KnockoutObservable<string>;
    public userPhone: KnockoutObservable<string>;
    public userEmail: KnockoutObservable<string>;
    public userPassword: KnockoutObservable<string>;
    public userPasswordConfirmation: KnockoutObservable<string>;

    constructor() {
        this.userName = ko.observable("").extend({
            required: true,
            minLength: 1,
            maxLength: 50
        });
        this.userSurname = ko.observable("").extend({
            required: true,
            minLength: 1,
            maxLength: 50
        });
        this.userPhone = ko.observable("").extend({
            required: true,
            phoneUS: true
        });
        this.userEmail = ko.observable("").extend({
            required: true,
            email: true
        });
        this.userPassword = ko.observable("").extend({
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

        let self = this;
        this.userPasswordConfirmation = ko.observable("").extend({
            required: true,
            areSame: {
                params: self.userPassword,
                message: "Please, confirm your password"
            }
        });

        this.dataService = new DataService();

        this.onSubmit.bind(this);
    }

    public onSubmit(): void {
        let viewModel = <KnockoutValidationGroup> ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.dataService.post("/api/account/register", {
                userName: this.userName(),
                userSurname: this.userSurname(),
                userPhone: this.userPhone(),
                userEmail: this.userEmail(),
                userPassword: this.userPassword()
            }).then(this.handleServiceResponse);
        }
        else {
            viewModel.errors.showAllMessages();
        }
    }

    private handleServiceResponse(response) {

        console.log("Register: response");
        console.log(response);
    }
}

export = SignUpViewModel;