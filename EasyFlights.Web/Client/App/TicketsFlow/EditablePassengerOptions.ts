import ko = require("knockout");

import { Sex } from "../Common/Enum/Enums";
import { IEditablePassengerOptions } from "./BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";
import { IEditableTicketOptions } from "./BaseComponents/TicketInfo/EditableTicket/IEditableTicketOptions";

export class EditablePassengerOptions implements IEditablePassengerOptions {
    firstName: KnockoutObservable<string>;
    lastName: KnockoutObservable<string>;
    birthday: KnockoutObservable<string>;
    documentNumber: KnockoutObservable<string>;
    sex: KnockoutObservable<Sex>;
    tickets: KnockoutObservableArray<IEditableTicketOptions>;

    constructor() {
        this.firstName = ko.observable("");
        this.lastName = ko.observable("");
        this.birthday = ko.observable("");
        this.documentNumber = ko.observable("");
        this.sex = ko.observable(Sex.Male);
        this.tickets = ko.observableArray([]);
    }
}