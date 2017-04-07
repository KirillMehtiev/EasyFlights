export class ProfileItem {

    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;
    public birthday: KnockoutObservable<string>;
    public sex: KnockoutObservable<string>;
    public contactPhone: KnockoutObservable<string>;
    public email: KnockoutObservable<string>;

    constructor(firstName: KnockoutObservable<string>, lastName: KnockoutObservable<string>, birthday: KnockoutObservable<string>, sex: KnockoutObservable<string>, contactPhone: KnockoutObservable<string>, email: KnockoutObservable<string>) {
        this.contactPhone = contactPhone;
        this.sex = sex;
        this.birthday = birthday;
        this.lastName = lastName;
        this.firstName = firstName;
        this.email = email;
    }
}