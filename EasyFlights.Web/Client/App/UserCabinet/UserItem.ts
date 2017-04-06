import ko = require("knockout");

export class UserItem {

    public firstName: string;
    public lastName: string;
    public birthday: string;
    public sex: string;
    public contactPhone: string;
    public email: string;

    constructor(firstName: string, lastName: string, birthday: string, sex: string, contactPhone: string, email: string) {
        this.contactPhone = contactPhone;
        this.sex = sex;
        this.birthday = birthday;
        this.lastName = lastName;
        this.firstName = firstName;
        this.email = email;
    }
}