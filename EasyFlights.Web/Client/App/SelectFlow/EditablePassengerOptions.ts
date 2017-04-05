import ko = require("knockout");
import { IEditablePassengerOptions } from "./PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { Sex } from "../Common/Enum/Enums";

export class EditablePassengerOptions implements IEditablePassengerOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    birthday: KnockoutObservable<string>;
    documentNumber: KnockoutObservable<string>;
    sex: KnockoutObservable<Sex>;

    constructor() {
        this.firstName = ko.observable("");
        this.lastName = ko.observable("");
        this.birthday = ko.observable("");
        this.documentNumber = ko.observable("");
        this.sex = ko.observable(0);
    }
}