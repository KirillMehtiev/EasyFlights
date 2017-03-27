import ko = require("knockout");
import moment = require("moment");
import { RadioChooserItem } from "../../CommonComponents/RadioChooser/RadioChooserItem";
import Item = require("./Autocomplete/CityItem/CityItem");

class TicketType {
    static oneWay = "OneWay";
    static roundTrip = "RoundTrip";
}
class DatePickerType {
    static departureDate = "departureDate";
    static returnDate = "returnDate";
}
class SearchViewModel {
    private options: Array<RadioChooserItem>;
    public cityList: Array<Item.CityItem>;

    public selectedTicketType: KnockoutObservable<string>;
    public selectedDepartureDate: KnockoutObservable<string>;
    public selectedReturnDate: KnockoutObservable<string>;
    public isRoundTripSelected: KnockoutObservable<boolean>;
    public searchCityFrom: KnockoutObservable<string>;
    public searchCityTo: KnockoutObservable<string>;
    public departureDateName: KnockoutObservable<string>;
    public returnDateName: KnockoutObservable<string>;
    public numberOfPeople: KnockoutObservable<number>;

    constructor() {
        this.options = [
            new RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.cityList = [new Item.CityItem("City 1", 1), new Item.CityItem("City 2", 2)];

        this.departureDateName = ko.observable(DatePickerType.departureDate);
        this.returnDateName = ko.observable(DatePickerType.returnDate);

        this.selectedTicketType = ko.observable(TicketType.oneWay);

        this.selectedDepartureDate = ko.observable("").extend({
            dateAfter: moment().format("L")
        });

        this.selectedReturnDate = ko.observable("").extend({
            dateAfter: moment().add(1, "day").format("L")
        });

        this.searchCityFrom = ko.observable<string>();
        this.searchCityTo = ko.observable<string>();

        this.isRoundTripSelected = ko.observable(false);

        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
        this.numberOfPeople = ko.observable(1);
    }

    public onTicketTypeChanged(newValue: string) {
        this.isRoundTripSelected(newValue === TicketType.roundTrip);

        // clean a return date if don't need it'
        if (!this.isRoundTripSelected()) {
            this.selectedReturnDate("");
        }
    }
}

export = SearchViewModel;