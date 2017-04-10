import ko = require("knockout");
import { DataService } from '../../../Common/Services/dataService';
import { IOrderFullInfoOptions } from "./IOrderFullInfoOptions";
import OrderFullInfoModel = require("./Models/OrderFullInfoModel");
import TicketFullInfoModel = require("./Models/TicketFullInfoModel");
import { Sex } from "../../../Common/Enum/Enums";

class OrderFullInfoViewModel {
    private dataService: DataService;

    public orderId: KnockoutObservable<number>;
    public order: KnockoutObservable<OrderFullInfoModel>;
    public isDataLoading: KnockoutObservable<boolean>;

    constructor(options: IOrderFullInfoOptions) {
        this.dataService = new DataService();

        this.orderId = options.orderId;
        this.order = ko.observable<OrderFullInfoModel>(new OrderFullInfoModel());
        this.isDataLoading = ko.observable(false);

        this.loadOrderInfo();
    }

    private loadOrderInfo(): void {
        this.isDataLoading(true);
        this.dataService
            .get("api/orders/GetById?orderId=" + this.orderId().toString())
            .then(response => {
                this.order(this.mapResponseToModel(response));
            })
            .always(() => this.isDataLoading(false));
    }

    private mapResponseToModel(response) {
        let order = new OrderFullInfoModel();
        order.orderDate(response.orderDate);
        for (let i = 0; i < response.tickets.length; i++) {
            let t = response.tickets[i];
            let ticket = new TicketFullInfoModel();

            ticket.firstName(t.firstName);
            ticket.lastName(t.lastName);
            ticket.birthday(t.birthday);
            ticket.documentNumber(t.documentNumber);
            ticket.sex(t.sex);
            ticket.departureAirport(t.departurePlace);
            ticket.destinationAirport(t.destinationPlace);
            ticket.duration(t.duration);
            ticket.price(t.price);
            ticket.departureTime(t.departureDate);
            ticket.arrivalTime(t.arrivalTime);
            ticket.seat(t.seat);

            order.tickets.push(ticket);
        }
        return order;
    }
}

export = OrderFullInfoViewModel;