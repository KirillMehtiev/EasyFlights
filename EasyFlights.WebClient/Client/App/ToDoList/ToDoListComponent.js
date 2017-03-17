"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
ko.components.register('todo-list', {
    viewModel: require('./ToDoListViewModel'),
    template: require('./ToDoListTemplate.html')
});
