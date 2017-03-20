import ko = require("knockout");

ko.components.register('todo-list-item', {
    viewModel: require('./ToDoListItemViewModel'),
    template: require('./ToDoListItemTemplate.html')
});