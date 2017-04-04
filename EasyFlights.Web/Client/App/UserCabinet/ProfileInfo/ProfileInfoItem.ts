import ko = require("knockout");

export class ProfileInfoItem {
   
    public firstName: string;
    public lastName: string;
    public birthday: string;
    public sex: string;
    public contactPhone: string;

    constructor(firstName: string, lastName: string, birthday: string, sex: string, contactPhone: string ) {
        this.contactPhone = contactPhone;
        this.sex = sex;
        this.birthday = birthday;
        this.lastName = lastName;
        this.firstName = firstName;
    }
}