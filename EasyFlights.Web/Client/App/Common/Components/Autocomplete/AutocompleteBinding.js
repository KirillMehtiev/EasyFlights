"use strict";
var ko = require("knockout");
var $ = require("jquery");
var dataService = require("../../Services/dataService");
var AutocompleteBinding = (function () {
    function AutocompleteBinding() {
    }
    AutocompleteBinding.prototype.init = function (element, valueAccessor, allBindingsAccessor) {
        var settings = valueAccessor();
        var service = new dataService.DataService();
        $(element).autocomplete({
            source: function (request, response) {
                var autocompleteUrl = settings.sourceUrl + request.term;
                service.ajaxGet(autocompleteUrl).then(function (data) { return response($
                    .map(data, function (item) { return ({ label: item.name, value: item.name }); })); });
            },
            minLength: 2
        });
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).autocomplete("destroy");
        });
    };
    return AutocompleteBinding;
}());
module.exports = AutocompleteBinding;
//# sourceMappingURL=AutocompleteBinding.js.map