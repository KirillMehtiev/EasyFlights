import ko = require("knockout");
import { FlightItem } from "./FlightResults/FlightItem";

class SearchResultViewModel {

    public flightItems: KnockoutObservableArray<FlightItem>;

    constructor() {
        this.flightItems = ko.observableArray([new FlightItem(12, "Flight", "Country", "Economy", "13:30", "City", "2 h 20 min", "15:50")
            , new FlightItem(12, "Flight", "Country", "Economy", "13:30", "City", "2 h 20 min", "15:50")
        ]);
        
    }
     

}

export = SearchResultViewModel;