import autocompleteViewModel = require('./AutocompleteViewModel');
import ko = require("knockout");

ko.components.register("auto-complete", {
    viewModel: autocompleteViewModel,
    template: require("./AutocompleteTemplate.html")
});