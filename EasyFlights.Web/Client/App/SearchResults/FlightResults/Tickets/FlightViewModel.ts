import { FlightItem } from "./FlightItem"
import { IFlightOptions } from "./IFlightOptions"

class FlightViewModel {


    public item: FlightItem;

    constructor(options: IFlightOptions) {
        this.item = options.item;

    }

}

export = FlightViewModel