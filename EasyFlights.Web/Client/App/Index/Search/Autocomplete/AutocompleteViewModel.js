"use strict";
var AutocompleteViewModel = (function () {
    function AutocompleteViewModel(options) {
        this.searchCity = options.searchCity;
        this.label = options.label;
        this.loadCities.bind(this);
    }
    AutocompleteViewModel.prototype.loadCities = function (obj, event) {
        $("#query").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Typehead/GetCitiesForTypeahead",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) { return ({ label: item.Name, value: item.Name }); }));
                    }
                });
            },
            minLength: 3,
            select: this.onCityCheck
        });
    };
    AutocompleteViewModel.prototype.onCityCheck = function (event, ui) {
    };
    return AutocompleteViewModel;
}());
module.exports = AutocompleteViewModel;
//# sourceMappingURL=AutocompleteViewModel.js.map