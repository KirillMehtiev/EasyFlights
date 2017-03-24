"use strict";
var $ = require("jquery");
var AutocompleteViewModel = (function () {
    function AutocompleteViewModel(options) {
        this.searchCity = options.searchCity;
        this.label = options.label;
        this.direction = options.direction;
        this.loadCities();
    }
    AutocompleteViewModel.prototype.loadCities = function () {
        var name = "#" + this.direction;
        var element = $(name).find("input");
        $(element).autocomplete({
            source: function (request, response) {
                console.log("Hi");
                var autocompleteUrl = '/api/Typeahead' + '?name=' + request.term;
                $.ajax({
                    url: autocompleteUrl,
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) { return ({ label: item.City + ", " + item.Name, value: item.Name }); }));
                    }
                });
            },
            minLength: 1
        });
    };
    return AutocompleteViewModel;
}());
module.exports = AutocompleteViewModel;
//# sourceMappingURL=AutocompleteViewModel.js.map