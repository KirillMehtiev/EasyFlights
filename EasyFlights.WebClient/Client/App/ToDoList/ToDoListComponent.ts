import ko = require("knockout");

ko.components.register('todo-list', {
    viewModel: require('./ToDoListViewModel'),
    template: require('./ToDoListTemplate.html')
});