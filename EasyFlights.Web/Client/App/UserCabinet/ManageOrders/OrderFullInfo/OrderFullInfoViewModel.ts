import ko = require("knockout");
import { DataService } from '../../../Common/Services/dataService';
import { IOrderFullInfoOptions } from "./IOrderFullInfoOptions";
import OrderFullInfoModel = require("./OrderFullInfoModel");

class OrderFullInfoViewModel {
    private dataService: DataService;

    public orderId: number;
    public order: KnockoutObservable<OrderFullInfoModel>;
    public isDataLoading: KnockoutObservable<boolean>;

    constructor(options: IOrderFullInfoOptions) {
        this.orderId = options.orderId;

        this.order = ko.observable<OrderFullInfoModel>();
        this.isDataLoading = ko.observable(false);
    }

    private loadOrderInfo(): void {
        this.isDataLoading(true);
        this.dataService
            .get("api/orders/getOrderById?orderId=" + this.orderId.toString())
            .then(response => this.order(this.mapResponseToModel(response)))
            .always(() => this.isDataLoading(false));
    }

    private mapResponseToModel(response) {
        let order = new OrderFullInfoModel();


        return order;
    }
}

export = OrderFullInfoViewModel;