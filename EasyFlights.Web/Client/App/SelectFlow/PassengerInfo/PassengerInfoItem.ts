import ko = require("knockout");

export class PassengerInfoItem {
    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;
    public ageType: KnockoutObservable<string>;
    public sex: KnockoutObservable<string>;
    public documentNumber: KnockoutObservable<string>;

    constructor() {
        this.firstName = ko.observable("");
        this.lastName = ko.observable("");
        this.ageType = ko.observable("");
        this.sex = ko.observable("");
        this.documentNumber = ko.observable("");
    }
}
