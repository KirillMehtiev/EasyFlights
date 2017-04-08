import ko = require("knockout");
import { DataService } from "../../Common/Services/dataService";
import { ManageOrdersItem } from "./ManageOrdersItem";
import swal = require("sweetalert");

class ManageOrdersViewModel {
    public dataService: DataService = new DataService();

    public orders: KnockoutObservableArray<ManageOrdersItem>;
    public isRequestProcessing: KnockoutObservable<boolean>;
    public areOrdersEmpty:KnockoutObservable<boolean>;
    private url: string = "api/Orders/GetOrdersForUser";
    private deleteBaseUrl: string = "api/Orders/Delete";

    constructor() {
        this.orders = ko.observableArray([]);
        this.isRequestProcessing = ko.observable(false);
        this.areOrdersEmpty = ko.observable(false);
        this.getOrdersForUser();
        this.deleteOrder.bind(this);
    }

    public deleteOrder(order: ManageOrdersItem) {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this order!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: true
        },
            () => {
                let index = this.orders().indexOf(order);
                let url = `${this.deleteBaseUrl}?orderId=${order.orderId}`;

                this.dataService.delete(url).then((result) => {
                    this.orders().slice(index, 1);
                    toastr.success("Action succesfully completed!", "Succes");
                });

            });
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