import ko = require("knockout");
import $ = require("jquery");
import dataService = require('../../Services/dataService');

class AutocompleteBinding implements KnockoutBindingHandler {
    public init(element: any, valueAccessor: any, allBindingsAccessor: KnockoutAllBindingsAccessor): void {
        let settings = valueAccessor();
        let service = new dataService.DataService();

        let updateElementValueWithLabel = (event, ui) => {
            event.preventDefault();
            $(element).val(ui.item.value);

            if(Boolean(ui.item)) {
                settings.selected(ui.item);
            }
        };

        $(element).autocomplete({
            source(request, response) {
                var autocompleteUrl = settings.sourceUrl + request.term;
                service.ajaxGet(autocompleteUrl).then(data => response($
                    .map(data, item => ({ label: item.label, value: item.value, id: item.id}))));
            },
            minLength: 2,
            select(event, ui) {
                updateElementValueWithLabel(event, ui);
            }
        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, () => {
            $(element).autocomplete("destroy");
        });
    }
}

export = AutocompleteBinding;