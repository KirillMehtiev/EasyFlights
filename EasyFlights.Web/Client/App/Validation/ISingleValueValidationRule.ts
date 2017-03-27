export interface ISingleValueValidationRule<T> {
    message: string;
    validator(inputValue: string, requiredValue: T): boolean;
}