"use strict";
var ko = require("knockout");
require("knockout.validation");
var DataService_1 = require("../Common/Services/DataService");
var LoginViewModel = (function () {
    function LoginViewModel() {
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
        this.rememberMe = ko.observable(false);
        this.dataService = new DataService_1.DataService();
        this.login.bind(this);
        this.handleServiceResponse.bind(this);
    }
    LoginViewModel.prototype.login = function () {
        var viewModel = ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.dataService.post("/api/account/login", {
                userEmail: this.userEmail(),
                userPassword: this.userPassword(),
                rememberMe: this.rememberMe()
            }).then(this.handleServiceResponse);
        }
        else {
            viewModel.errors.showAllMessages();
        }
    };
    ;
    LoginViewModel.prototype.handleServiceResponse = function (response) {
        console.log("Register: response");
        console.log(response);
    };
    return LoginViewModel;
}());
module.exports = LoginViewModel;
//# sourceMappingURL=LoginViewModel.js.map