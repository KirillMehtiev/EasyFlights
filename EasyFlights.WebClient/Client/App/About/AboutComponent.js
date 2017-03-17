"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
ko.components.register('about', {
    viewModel: require('./AboutViewModel'),
    template: require('./AboutTemplate.html')
});
