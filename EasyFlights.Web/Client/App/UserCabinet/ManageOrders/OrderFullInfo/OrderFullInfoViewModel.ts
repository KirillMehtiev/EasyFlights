import ko = require("knockout");
import { IOrderFullInfoOptions } from "./IOrderFullInfoOptions";

class OrderFullInfoViewModel {
    public orderId: number;

    public order: KnockoutObservable<any>;

    constructor(options: IOrderFullInfoOptions) {
        this.orderId = options.orderId;

        this.order = ko.observable();
    }
}

export = OrderFullInfoViewModel;