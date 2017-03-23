import { CityItem } from "./CityItem/CityItem";
import { IAutocompleteOptions } from "./IAutocompleteOptions";

class AutocompleteViewModel {
    searchCity: KnockoutObservable<string>;
    label: string;

    constructor(options: IAutocompleteOptions) {
        this.searchCity = options.searchCity;
        this.label = options.label;
        this.loadCities.bind(this);
    }

    loadCities(obj, event): void {
        $("#query").autocomplete({
            source(request, response) {
                $.ajax({
                    url: "/Typehead/GetCitiesForTypeahead",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success(data) {
                        response($.map(data, item => ({ label: item.Name, value: item.Name })));
                    }
                });
            },  
            minLength: 3,
            select: this.onCityCheck
        });
    }

    onCityCheck(event: Event, ui : JQueryUI.AutocompleteUIParams) : void {       
    }
}


export = AutocompleteViewModel;