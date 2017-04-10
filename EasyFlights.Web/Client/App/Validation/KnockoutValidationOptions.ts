class KnockoutValidationOptions {
    public insertMessages: boolean;
    public decorateInputElement: boolean;
    public errorsAsTitle: boolean;
    public errorElementClass: string;
    public errorMessageClass: string;
    public grouping: any;

    constructor() {
        this.insertMessages = true;
        this.decorateInputElement = true;
        this.errorsAsTitle = false;

        this.errorElementClass = "input-has-error";
        this.errorMessageClass = "validation-message";

        this.grouping = {
            deep: true,
            live: true,
            observable: true
        }
    }
}

export = KnockoutValidationOptions;