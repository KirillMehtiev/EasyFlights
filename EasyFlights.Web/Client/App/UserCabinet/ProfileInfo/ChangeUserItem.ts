import { Sex } from "../../Common/Enum/Enums";
export class ChangeUserItem {

    public firstName: string;
    public lastName: string;
    public dateOfBirth: string;
    public contactPhone: string;
    public email: string;
    public sex: Sex;



    constructor(firstName: string, lastName: string, dateOfBirth: string, contactPhone: string, email: string, sex: Sex) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.contactPhone = contactPhone;
        this.email = email;
        this.sex = sex;
    }
}