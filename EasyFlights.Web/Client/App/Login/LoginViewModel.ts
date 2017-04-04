import ko = require("knockout");
require("knockout.validation");
import { DataService } from "../Common/Services/DataService";

class LoginViewModel {
    public userEmail: KnockoutObservable<string>;
    public userPassword: KnockoutObservable<string>;
    public rememberMe: KnockoutObservable<boolean>;
    private dataService: DataService;

    constructor() {
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

        this.dataService = new DataService();

        this.login.bind(this);
        this.handleServiceResponse.bind(this);
    }

    public login(): void {
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable(this);
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

    private handleServiceResponse(response) {
        console.log("Register: response");
        console.log(response);
    }
}

export = LoginViewModel