import ko = require("knockout");
import { RadioChooserItem } from "./RadioChooser/RadioChooserItem";

class TicketType {
    static oneWay = "OneWay";
    static roundTrip = "RoundTrip";
}

class SearchViewModel {
    private options: Array<RadioChooserItem>;
    
    public selectedTicketType: KnockoutObservable<string>;

    constructor() {
        this.options = [
            new RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.selectedTicketType = ko.observable(TicketType.oneWay);
    }
}

export = SearchViewModel;