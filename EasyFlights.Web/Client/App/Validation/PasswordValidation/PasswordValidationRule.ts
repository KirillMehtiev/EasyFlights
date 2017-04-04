import { ISingleValueValidationRule } from "../ISingleValueValidationRule";
import { IPasswordValidationOptions } from "./IPasswordValidationOptions";

class PasswordValidationRule implements ISingleValueValidationRule<IPasswordValidationOptions> {

    public message: string = "Password does not match security rules";

    constructor() {
        this.hasUpperCaseLetter.bind(this);
        this.hasDigit.bind(this);
    }

    public validator(inputValue: string, requiredValue: IPasswordValidationOptions): boolean {

        return inputValue.length >= requiredValue.minLength &&
            inputValue.length <= requiredValue.maxLenght &&
            requiredValue.shouldContainAtLeastOneCapitalLetter ? this.hasUpperCaseLetter(inputValue) : true &&
            requiredValue.shouldContainAtLeastOneDigit ? this.hasDigit(inputValue) : true &&
            requiredValue.shouldContainAtLeastOneLowerCaseLetter ? this.hasLowerCaseLetter(inputValue) : true;
    };

    private hasUpperCaseLetter(str: string): boolean {
        return (/[A-Z]/.test(str));
    }

    private hasDigit(str: string): boolean {
        return (/[0-9]/.test(str));
    }

    private hasLowerCaseLetter(str: string) {
        return (/[a-z]/.test(str));
    }
}

export = PasswordValidationRule;