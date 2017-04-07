import ko = require("knockout");
import TicketFullInfoModel = require("./TicketFullInfoModel");

class OrderFullInfoModel {
    public orderDate: KnockoutObservable<string>;
    public tickets: KnockoutObservableArray<TicketFullInfoModel>;

    constructor() {
        this.orderDate = ko.observable("");
        this.tickets = ko.observableArray([]);
    }
}

export = OrderFullInfoModel;