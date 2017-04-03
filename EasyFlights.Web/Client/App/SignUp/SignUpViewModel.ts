import ko = require("knockout");
require("knockout.validation");

class SignUpViewModel {

    public userName: KnockoutObservable<string>;
    public userSurname: KnockoutObservable<string>;
    public userPhone: KnockoutObservable<string>;
    public userEmail: KnockoutObservable<string>;
    public userPassword: KnockoutObservable<string>;
    public userPasswordConfirmation: KnockoutObservable<string>;

    constructor() {
        this.userName = ko.observable("").extend({
            required: true,
            min: 2
        });
        this.userSurname = ko.observable("").extend({
            required: true,
            min: 2
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
            required: true
        });

        let self = this;
        this.userPasswordConfirmation = ko.observable("").extend({
            required: true,
            areSame: {
                params: self.userPassword,
                message: "Please, confirm your password"
            }
        });

        this.onSubmit.bind(this);
    }

    public onSubmit(): void {
        let viewModel = ko.validatedObservable(this);

        if (viewModel.isValid()) {

            // TODO: send request to the server

            console.log("valid");
        }
        else {
            viewModel.errors.showAllMessages();
        }
    }
}

export = SignUpViewModel;