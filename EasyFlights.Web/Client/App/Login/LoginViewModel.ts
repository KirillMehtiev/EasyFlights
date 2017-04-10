﻿import ko = require("knockout");
require("knockout.validation");
import { AuthService } from "../Common/Services/Auth/authService";
import { DataService } from "../Common/Services/dataService";
import { TicketsFlowService } from "../TicketsFlow/Services/TicketsFlowService"

class LoginViewModel {
    public userEmail: KnockoutObservable<string>;
    public userPassword: KnockoutObservable<string>;
    public rememberMe: KnockoutObservable<boolean>;
    public isRequestProcessing: KnockoutObservable<boolean>;
    public dataService: DataService = new DataService();
    public ticketsFlowService: TicketsFlowService = new TicketsFlowService();

    private urlToBookTickets: string = "api/orders/BookTickets";
    constructor() {
        this.createDefaultOptions();
    }

    public facebookLogin(): void {
        AuthService.current.externalLogin("Facebook");
    }
    public googleLogin(): void {
        AuthService.current.externalLogin("Google");
    }

    public login(): void {
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
        if (viewModel.isValid()) {
            this.isRequestProcessing(true);

            AuthService.current.signIn({
                userEmail: this.userEmail(),
                userPassword: this.userPassword(),
                rememberMe: this.rememberMe()
            }).then((response) => {
                    this.handleServiceResponse(response); 
                    var filledData = window.localStorage.getItem("filledData");
                    if (filledData !== null) {
                        this.ticketsFlowService
                            .bookTickets(JSON.parse(filledData))
                            .then(() => {
                                if (AuthService.current.isCurrentUserSignedIn) {
                                    window.localStorage.removeItem("filledData");
                                    window.location.href = "#";
                                }
                            });
                    }
                })
                .always(() => this.isRequestProcessing(false));
        }
        else {
            viewModel.errors.showAllMessages();
        }
    };

    private handleServiceResponse(response) {
        console.log("Register: response");
        console.log(response);
    }

    private createDefaultOptions() {
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
        this.isRequestProcessing = ko.observable(false);

        this.login.bind(this);
        this.handleServiceResponse.bind(this);
    }
}

export = LoginViewModel