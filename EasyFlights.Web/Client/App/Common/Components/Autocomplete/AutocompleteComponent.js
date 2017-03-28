"use strict";
exports.__esModule = true;
var autocompleteViewModel = require("./AutocompleteViewModel");
var ko = require("knockout");
ko.components.register("auto-complete", {
    viewModel: autocompleteViewModel,
    template: require("./AutocompleteTemplate.html")
});
//# sourceMappingURL=AutocompleteComponent.js.map