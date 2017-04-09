export class ProfileItem {

    public firstName: string;
    public lastName: string;
    public dateOfBirth: string;
    public contactPhone: string;
    public email: string;
    public sex: string;



    constructor(firstName: string, lastName: string, dateOfBirth: string, contactPhone: string, email:string, sex: string) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.contactPhone = contactPhone;
        this.email = email;
        this.sex = sex;
    }
}