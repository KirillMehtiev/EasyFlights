import $ = require("jquery");
import { CityItem } from "./CityItem/CityItem";
import { IAutocompleteOptions } from "./IAutocompleteOptions";

class AutocompleteViewModel {
    searchCity: KnockoutObservable<string>;
    label: string;
    direction: string;

    constructor(options: IAutocompleteOptions) {
        this.searchCity = options.searchCity;
        this.label = options.label;
        this.direction = options.direction;
        this.loadCities();
    }

    loadCities(): void {
       $("#dir_From").autocomplete({
            source(request, response) {
                console.log("Hi");
                var autocompleteUrl = '/api/Typeahead' + '?name=' + request.term;
                $.ajax({
                    url: autocompleteUrl,
                    type: "GET",
                    dataType: "json",
                    success(data) {
                        response($.map(data, item => ({ label: item.City + ", "+item.Name, value: item.Name })));
                    }
                });
            },  
            minLength: 1
        });
    }
}


export = AutocompleteViewModel;