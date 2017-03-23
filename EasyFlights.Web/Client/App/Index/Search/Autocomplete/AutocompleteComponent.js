"use strict";
exports.__esModule = true;
var autocompleteviewmodel = require("./AutocompleteViewModel");
var ko = require("knockout");
ko.components.register("autocomplete", {
    viewModel: autocompleteviewmodel,
    template: require("./AutocompleteTemplate.html")
});
//# sourceMappingURL=AutocompleteComponent.js.map