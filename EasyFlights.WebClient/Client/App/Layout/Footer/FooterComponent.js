"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
ko.components.register('app-footer', {
    viewModel: require('./FooterViewModel'),
    template: require('./FooterTemplate.html')
});
