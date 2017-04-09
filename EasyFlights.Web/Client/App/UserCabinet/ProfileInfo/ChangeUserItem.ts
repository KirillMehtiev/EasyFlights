export class ChangeUserItem {

    public firstName: string;
    public lastName: string;
    public birthday: string;
    public contactPhone: string;
    public email: string;
    public sex: string;



    constructor(firstName: string, lastName: string, birthday: string, contactPhone: string, email: string, sex: string) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthday = birthday;
        this.contactPhone = contactPhone;
        this.email = email;
        this.sex = sex;

    }
}