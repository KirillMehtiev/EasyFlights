import ko = require("knockout");
import { RouteItem } from "./RouteItem";
import { IRouteItemOptions } from "./IRouteItemOptions";
import { FlightItem } from "./Tickets/FlightItem";

class RouteResultViewModel {
  
    public item: RouteItem;
    //public countOf: KnockoutObservable<number>;

    constructor(options: IRouteItemOptions) {
      
        this.item = options.item;
        //this.countOf = params.countOf;

    }

}

export = RouteResultViewModel