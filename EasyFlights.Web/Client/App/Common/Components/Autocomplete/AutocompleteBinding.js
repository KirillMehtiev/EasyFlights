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
        var updateElementValueWithLabel = function (event, ui) {
            event.preventDefault();
            $(element).val(ui.item.value);
            if (typeof ui.item !== "undefined") {
                settings.selected(ui.item);
            }
        };
        $(element).autocomplete({
            source: function (request, response) {
                var autocompleteUrl = settings.sourceUrl + request.term;
                service.ajaxGet(autocompleteUrl).then(function (data) { return response($
                    .map(data, function (item) { return ({ label: item.label, value: item.value, id: item.id }); })); });
            },
            minLength: 2,
            select: function (event, ui) {
                updateElementValueWithLabel(event, ui);
            }
        });
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).autocomplete("destroy");
        });
    };
    return AutocompleteBinding;
}());
module.exports = AutocompleteBinding;
//# sourceMappingURL=AutocompleteBinding.js.map