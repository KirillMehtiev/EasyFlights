import { IRouteHeaderOptions } from "./IRouteHeaderOptions";

class RouteHeaderViewModel {
    public departurePlace: KnockoutObservable<string>;
    public destinationPlace: KnockoutObservable<string>;
    public departureDate: KnockoutObservable<string>;
    public returnDate: KnockoutObservable<string>;

    constructor(options: IRouteHeaderOptions) {
        this.departurePlace = options.departurePlace;
        this.destinationPlace = options.destinationPlace;
        this.departureDate = options.departureDate;
        this.returnDate = options.returnDate;
    }

}

export = RouteHeaderViewModel;