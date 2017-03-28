import ko = require("knockout");
import $ = require("jquery");
import dataService = require('../../Services/dataService');

class AutocompleteBinding implements KnockoutBindingHandler {
    public init(element: any, valueAccessor: any, allBindingsAccessor: KnockoutAllBindingsAccessor): void {
        let settings = valueAccessor();
        let service = new dataService.DataService();

        $(element).autocomplete({
            source(request, response) {
                var autocompleteUrl = settings.sourceUrl + request.term;
                service.ajaxGet(autocompleteUrl).then(data => response($
                    .map(data, item => ({ label: item.name, value: item.name }))));
            },
            minLength: 2
        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, () => {
            $(element).autocomplete("destroy");
        });
    }
}

export = AutocompleteBinding;