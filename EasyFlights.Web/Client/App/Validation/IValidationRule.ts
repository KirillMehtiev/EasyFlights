export interface IValidationRule {
    message: string;
    validator(inputValue: any, requiredValue: any): boolean;
}