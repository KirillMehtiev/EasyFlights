import { Sex } from "../../../../Common/Enum/Enums";

class TicketFullInfoModel {
    public firstName: KnockoutObservable<string>;
    public lastName: KnockoutObservable<string>;
    public birthday: KnockoutObservable<string>;
    public documentNumber: KnockoutObservable<string>;
    public sex: KnockoutObservable<Sex>;
    public departureAirport: KnockoutObservable<string>;
    public destinationAirport: KnockoutObservable<string>;
    public duration: KnockoutObservable<string>;
    public price: KnockoutObservable<string>;
    public departureTime: KnockoutObservable<string>;
    public arrivalTime: KnockoutObservable<string>;
    public seat: KnockoutObservable<number>;

    constructor() {
        this.firstName = ko.observable("");
        this.lastName = ko.observable("");
        this.birthday = ko.observable("");
        this.documentNumber = ko.observable("");
        this.sex = ko.observable<Sex>();
        this.departureAirport = ko.observable("");
        this.destinationAirport = ko.observable("");
        this.duration = ko.observable("");
        this.price = ko.observable("");
        this.departureTime = ko.observable("");
        this.arrivalTime = ko.observable("");
        this.seat = ko.observable<number>();
    }
}

export = TicketFullInfoModel;