import ko = require("knockout");
import { FlightItem } from "./FlightItem";
import { IFlightItemOptions } from "./IFlightItemOptions";
import { TicketItem } from "./Tickets/TicketItem";

class FlightResultViewModel {
    
   
    public item: FlightItem;
    

    constructor(options: IFlightItemOptions) {
      
        this.item = options.item;

    }

}

export = FlightResultViewModel