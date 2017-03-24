"use strict";
var AutocompleteViewModel = (function () {
    function AutocompleteViewModel(options) {
        this.searchCity = options.searchCity;
        this.label = options.label;
        this.direction = options.direction;
        this.loadCities();
    }
    AutocompleteViewModel.prototype.loadCities = function () {
        $("#dir_From").autocomplete({
            source: function (request, response) {
                var autocompleteUrl = '/api/Typeahead' + '?name=' + request.term;
                $.ajax({
                    url: autocompleteUrl,
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) { return ({ label: item.City + ", " + item.Name, value: item.Name }); }));
                        this.searchCity = response;
                    }
                });
            },
            minLength: 3
        });
    };
    return AutocompleteViewModel;
}());
module.exports = AutocompleteViewModel;
//# sourceMappingURL=AutocompleteViewModel.js.map