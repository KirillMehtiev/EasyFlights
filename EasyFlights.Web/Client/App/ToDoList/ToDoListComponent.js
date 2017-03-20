"use strict";
exports.__esModule = true;
var ko = require("knockout");
ko.components.register('todo-list', {
    viewModel: require('./ToDoListViewModel'),
    template: require('./ToDoListTemplate.html')
});
//# sourceMappingURL=ToDoListComponent.js.map