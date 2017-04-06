import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";

class ManageOrdersViewModel {
    public dataService: DataService = new DataService();

    public orders: KnockoutObservableArray<any>;
    public isRequestProcessing: KnockoutObservable<boolean>;

    private url: string = "api/Cabinet/GetOrdersForUser"

    constructor() {
        this.isRequestProcessing = ko.observable(false);
        this.getOrdersForUser();
    }

    private getOrdersForUser() {
        this.isRequestProcessing(true);
        this.dataService.get<any[]>(this.url)
            .then((data) => {
                this.orders = ko.observableArray(data);
            }).always(() => this.isRequestProcessing(false));;
    } 
}

export = ManageOrdersViewModel;