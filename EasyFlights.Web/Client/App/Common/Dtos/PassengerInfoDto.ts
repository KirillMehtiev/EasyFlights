import { Sex } from "../Enum/Enums"

export class PassengerInfoDto {
    public firstName: string;
    public lastName: string;
    public birthday: string;
    public documentNumber: string;
    public sex: Sex;
}