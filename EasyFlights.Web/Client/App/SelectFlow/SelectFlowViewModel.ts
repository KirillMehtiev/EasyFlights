class OrderSummaryViewModel {
    public routeId: string;
    public numberOfPassenger: number;

    constructor(params) {
        this.routeId = params.routeId;
        this.numberOfPassenger = params.numberOfPassenger;
    }
}

export = OrderSummaryViewModel;