import ko = require("knockout");

ko.components.register('editable-passenger', {
    viewModel: require('./EditablePassengerViewModel'),
    template: require('./EditablePassengerTemplate.html')
});