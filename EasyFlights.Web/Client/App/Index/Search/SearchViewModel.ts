import ko = require("knockout");
import { RadioChooserItem } from "./RadioChooser/RadioChooserItem";

class TicketType {
    static oneWay = "OneWay";
    static roundTrip = "RoundTrip";
}

class SearchViewModel {
    private options: Array<RadioChooserItem>;
    
    public selectedTicketType: KnockoutObservable<string>;
    public selectedDepartureDate: KnockoutObservable<string>;
    public selectedReturnDate: KnockoutObservable<string>;

    public isRoundTripSelected: KnockoutObservable<boolean>;

    constructor() {
        this.options = [
            new RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.selectedTicketType = ko.observable(TicketType.oneWay);
        this.selectedDepartureDate = ko.observable("");
        this.selectedReturnDate = ko.observable("");

        this.isRoundTripSelected = ko.observable(false);

        this.selectedTicketType.subscribe(this.onTicketTypeChanged);
    }

    public onTicketTypeChanged = (newValue: string) => {
        this.isRoundTripSelected(newValue === TicketType.roundTrip);

        // clean a return date if don't need it'
        if (!this.isRoundTripSelected()) {
            this.selectedReturnDate("");
        }
    }
}

export = SearchViewModel;