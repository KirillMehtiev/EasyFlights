import ko = require("knockout");
import moment = require("moment");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";

class TicketType {
    static oneWay = "OneWay";
    static roundTrip = "RoundTrip";
}
class DatePickerType {
    static departureDate = "departureDate";
    static returnDate = "returnDate";
}
class SearchViewModel {
    private placeholderAutocomplete: string = "Search by country, city or airport";
    private options: Array<RadioChooserItem>;

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

        this.departureDateName = ko.observable(DatePickerType.departureDate);
        this.returnDateName = ko.observable(DatePickerType.returnDate);

        this.selectedTicketType = ko.observable(TicketType.oneWay);

        this.selectedDepartureDate = ko.observable("").extend({
            dateAfter: moment().format("L")
        });
        let self = this;
        this.selectedReturnDate = ko.observable("").extend({
            dateAfter: self.selectedDepartureDate
        });

        this.searchCityFrom = ko.observable<string>().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });
        this.searchCityTo = ko.observable<string>().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });

        this.numberOfPeople = ko.observable(1).extend({
            min: {
                params: 1,
                message: "This value has to be greater then {0}"
            },
            max: {
                params: 10,
                message: "This value has to be less then {0}"
            }
        });

        this.isRoundTripSelected = ko.observable(false);

        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
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