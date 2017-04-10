import ko = require("knockout");
require("knockout.validation");
import pager = require("pager");
import moment = require("moment");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import { TicketType } from "../../Common/Enum/Enums"
import Item = require("../../Common/Components/Autocomplete/AutocompleteItem");

class DatePickerType {
    static departureDate = "departureDate";
    static returnDate = "returnDate";
}
class SearchViewModel {
    private placeholderAutocomplete: string = "Search by country, city or airport";
    private options: Array<RadioChooserItem>;

    public searchAirportFrom: KnockoutObservable<Item.AutocompleteItem>;
    public searchAirportTo: KnockoutObservable<Item.AutocompleteItem>;

    public selectedTicketType: KnockoutObservable<TicketType>;
    public selectedDepartureDate: KnockoutObservable<string>;
    public selectedReturnDate: KnockoutObservable<string>;
    public isRoundTripSelected: KnockoutObservable<boolean>;
    public departureDateName: KnockoutObservable<string>;
    public returnDateName: KnockoutObservable<string>;
    public number: KnockoutObservable<number>;
    public numberOfPeople: KnockoutObservableArray<number>;

    constructor() {
        this.options = [
            new RadioChooserItem("One Way", TicketType.OneWay),
            new RadioChooserItem("Round trip", TicketType.RoundTrip)
        ];
        this.createDefaultOptions();
        this.departureDateName = ko.observable(DatePickerType.departureDate);
        this.returnDateName = ko.observable(DatePickerType.returnDate);

        this.selectedTicketType = ko.observable(TicketType.OneWay);

        this.selectedDepartureDate = ko.observable("").extend({
            requred:true,
            dateAfter: moment().format("L")
        });
        let self = this;

        this.selectedReturnDate = ko.observable("").extend({
            required: true,
            dateAfter: self.selectedDepartureDate
        });

        this.searchAirportFrom = ko.observable<Item.AutocompleteItem>().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });
        this.searchAirportTo = ko.observable<Item.AutocompleteItem>().extend({
            required: {
                params: true,
                message: 'This field is required.'
            }
        });

        this.isRoundTripSelected = ko.observable(false);

        this.onSearch = this.onSearch.bind(this);
        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
    }

    public onSearch() {
        let viewModel = <KnockoutValidationGroup>ko.validatedObservable([
                this.searchAirportFrom,
                this.searchAirportTo,
                this.selectedDepartureDate
        ]);

        if (!viewModel.isValid()) {
            viewModel.errors.showAllMessages();
        }
        else {
            if (this.isRoundTripSelected()) {
                let selectedReturnDateViewModel = <KnockoutValidationGroup>ko.validatedObservable(this.selectedReturnDate);

                if (!selectedReturnDateViewModel.isValid()) {
                    selectedReturnDateViewModel.errors.showAllMessages();
                    return;
                }
            }

            let searchResultsUrl: string = "results?" + 
                "departurePlace=" + this.searchAirportFrom().value + "&" + 
                "departurePlaceId=" + this.searchAirportFrom().id + "&" + 
                "arrivalPlace=" + this.searchAirportTo().value + "&" + 
                "arrivalPlaceId=" + this.searchAirportTo().id + "&" + 
                "departureDate=" + encodeURIComponent(this.selectedDepartureDate()) + "&" + 
                (this.selectedReturnDate() ? "returnDate=" + encodeURIComponent(this.selectedReturnDate()) + "&" : "") +
                "numberOfPassenger=" + this.number() + "&" + 
                "type=" + TicketType[this.selectedTicketType()];

            pager.navigate(searchResultsUrl);
        }
    }

    public onTicketTypeChanged(newValue: TicketType) {
        this.isRoundTripSelected(newValue === TicketType.RoundTrip);
        if (!this.isRoundTripSelected()) {
            this.selectedReturnDate("");
        }
    }

    private createDefaultOptions() {
        this.number = ko.observable(1);
        this.numberOfPeople = ko.observableArray<number>();
        for (let i = 1; i < 10; i++) {
            this.numberOfPeople.push(i);
        }
    }
}

export = SearchViewModel;