import autocompleteviewmodel = require("./AutocompleteViewModel");
import ko = require("knockout");

ko.components.register("autocomplete", {
    viewModel: autocompleteviewmodel,
    template: require("./AutocompleteTemplate.html")
});