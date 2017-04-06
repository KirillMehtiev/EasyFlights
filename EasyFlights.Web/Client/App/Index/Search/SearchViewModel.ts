import ko = require("knockout");
import moment = require("moment");
import { RadioChooserItem } from "../../Common/Components/RadioChooser/RadioChooserItem";
import Item = require("../../Common/Components/Autocomplete/AutocompleteItem");

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

    public searchAirportFrom: KnockoutObservable<Item.AutocompleteItem>;
    public searchAirportTo: KnockoutObservable<Item.AutocompleteItem>;

    public selectedTicketType: KnockoutObservable<string>;
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
            new RadioChooserItem("One Way", TicketType.oneWay),
            new RadioChooserItem("Round trip", TicketType.roundTrip)
        ];
        this.createDefaultOptions();
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
        //this.isSuccess = ko.observable(false);
        //this.isSuccess.subscribe(this.checked, this);
        this.checked.bind(this);
        this.selectedTicketType.subscribe(this.onTicketTypeChanged, this);
    }

    //public checked(): void {
    //        var viewModel = <KnockoutValidationGroup>ko.validatedObservable([this.searchAirportFrom, this.searchAirportTo, this.departureDateName]);
    //        if (viewModel.isValid()) {
    //            this.isSuccess = ko.observable(true);
    //            console.log("ok");
    //        }
        
    //        viewModel.errors.showAllMessages();
    //}

    public checked() {
        var viewModel = <KnockoutValidationGroup>ko.validatedObservable([this.searchAirportFrom, this.searchAirportTo, this.departureDateName]);
        if (viewModel.isValid()) {
            return true;
        }
        return false;
    }  

    public onTicketTypeChanged(newValue: string) {
        this.isRoundTripSelected(newValue === TicketType.roundTrip);
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