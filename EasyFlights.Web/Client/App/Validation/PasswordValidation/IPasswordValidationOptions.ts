export interface IPasswordValidationOptions {
    minLength: number;
    maxLenght: number;
    shouldContainAtLeastOneDigit: boolean;
    shouldContainAtLeastOneCapitalLetter: boolean;
}