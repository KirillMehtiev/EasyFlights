import ko = require("knockout");
import { FlightItem } from "./FlightResults/FlightItem";
import Item = require("./FlightResults/Tickets/TicketItem");
import TicketItem = Item.TicketItem;

class SearchResultViewModel {

    public flightItems: Array<FlightItem>;

    constructor() {

        this.flightItems = [new FlightItem(12, "Flight", "Country", "Economy", "13:30", [new TicketItem(12, "Flight", "Country", "Economy","rtt", "13:30", "City","2 h 20 min", "15:50","145")])
          ];
        
    }
     

}

export = SearchResultViewModel;