import { Sex } from "../../Common/Enum/Enums";

export interface IPassengerInfoItem {
    firstName: string;
    lastName: string;
    birthday: string;
    documentNumber: string;
    sex: Sex;
}