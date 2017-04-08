import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";
import { ManageOrdersItem } from "./ManageOrdersItem";

class ManageOrdersViewModel {
    public dataService: DataService = new DataService();

    public orders: KnockoutObservableArray<ManageOrdersItem>;
    public isRequestProcessing: KnockoutObservable<boolean>;
    public areOrdersEmpty:KnockoutObservable<boolean>;
    private url: string = "api/Orders/GetOrdersForUser";

    constructor() {
        this.orders = ko.observableArray([]);
        this.isRequestProcessing = ko.observable(false);
        this.areOrdersEmpty = ko.observable(false);
        this.getOrdersForUser();
    }

    private getOrdersForUser() {
        this.isRequestProcessing(true);
        this.dataService.get<Array<ManageOrdersItem>>(this.url)
            .then((data) => {
                this.orders(data);
                if (data.length === 0) {
                    this.areOrdersEmpty(true);
                }
            }).always(() => this.isRequestProcessing(false));;
    } 
}

export = ManageOrdersViewModel;