﻿import ko = require("knockout");
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
    //public isSuccess: KnockoutObservable<boolean>;



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
            dateAfter: moment().format("L")
        });
        let self = this;

        this.selectedReturnDate = ko.observable("").extend({
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

        this.checked.bind(this);
        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
    }

    public checked(): boolean {
        var viewModel = <KnockoutValidationGroup>ko.validatedObservable([this.searchAirportFrom, this.searchAirportTo, this.selectedDepartureDate]);
        if (viewModel.isValid()) {

            return true;
        }
        //viewModel.errors.showAllMessages();
        return false;

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