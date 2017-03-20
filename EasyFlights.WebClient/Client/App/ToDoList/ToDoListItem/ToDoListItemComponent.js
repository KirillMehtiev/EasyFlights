"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
ko.components.register('todo-list-item', {
    viewModel: require('./ToDoListItemViewModel'),
    template: require('./ToDoListItemTemplate.html')
});
