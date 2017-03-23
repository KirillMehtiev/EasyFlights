﻿import ko = require("knockout");
import { RadioChooserItem } from "./RadioChooser/RadioChooserItem";
import Item = require("./Autocomplete/CityItem/CityItem");

class TicketType {
    static oneWay = "OneWay";
    static roundTrip = "RoundTrip";
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

    constructor() {
        this.options = [
            new RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.cityList = [new Item.CityItem("City 1", 1), new Item.CityItem("City 2", 2)];

        this.selectedTicketType = ko.observable(TicketType.oneWay);
        this.selectedDepartureDate = ko.observable("");
        this.selectedReturnDate = ko.observable("");

        this.searchCityFrom = ko.observable<string>();
        this.searchCityTo = ko.observable<string>();

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