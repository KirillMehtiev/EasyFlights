"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
ko.components.register('app-layout', {
    viewModel: require("./LayoutViewModel"),
    template: require("./LayoutTemplate.html")
});
