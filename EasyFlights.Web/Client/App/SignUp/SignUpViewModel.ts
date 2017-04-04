import ko = require("knockout");
require("knockout.validation");

import { AuthService } from "../Common/Services/Auth/authService";

class SignUpViewModel {
    public userName: KnockoutObservable<string>;
    public userSurname: KnockoutObservable<string>;
    public userPhone: KnockoutObservable<string>;
    public userEmail: KnockoutObservable<string>;
    public userPassword: KnockoutObservable<string>;
    public userPasswordConfirmation: KnockoutObservable<string>;

    public isRequestProcessing: KnockoutObservable<boolean>;

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

        this.isRequestProcessing = ko.observable(false);

        this.onSubmit.bind(this);
        this.handleServiceResponse.bind(this);
    }

    public onSubmit(): void {
        let viewModel = <KnockoutValidationGroup> ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.isRequestProcessing(true);

            AuthService.current.SignUp({
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

    private handleServiceResponse(response: boolean) {

        console.log("Register: response");
        console.log(response);

        if (response) {
            // TODO: redirect somewhere
        }
        else {
            // TODO: show error message
        }


        this.isRequestProcessing(false);
    }
}

export = SignUpViewModel;