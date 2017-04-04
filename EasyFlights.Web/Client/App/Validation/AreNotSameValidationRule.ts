import { ISingleValueValidationRule } from "./ISingleValueValidationRule";

class AreNotSameValidationRule implements ISingleValueValidationRule<string> {

    public message: string = "This value has to be the same as {0}";

    public validator(inputValue: string, requiredValue: string): boolean {
        return inputValue !== requiredValue;
    };
}

export = AreNotSameValidationRule;