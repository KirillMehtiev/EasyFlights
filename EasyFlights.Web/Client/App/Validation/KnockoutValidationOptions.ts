class KnockoutValidationOptions {
    public insertMessages: boolean;
    public decorateInputElement: boolean;
    public errorsAsTitle: boolean;
    public errorElementClass: string;
    public errorMessageClass: string;
    

    constructor() {
        this.insertMessages = true;
        this.decorateInputElement = true;
        this.errorsAsTitle = false;

        this.errorElementClass = "has-error";
        this.errorMessageClass = "help-block validation-message";
    }
}

export = KnockoutValidationOptions;