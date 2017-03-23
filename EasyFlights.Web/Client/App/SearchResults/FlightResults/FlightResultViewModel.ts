import { FlightItem } from "./FlightItem"
import { IFlightItemOptions } from "./IFlightItemOptions"

class FlightResultViewModel {
    

    public item: FlightItem;
    public quanity: number;

    constructor(options: IFlightItemOptions) {
        this.item = options.item;
       
    }

}

export = FlightResultViewModel