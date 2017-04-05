import ko = require("knockout");

ko.components.register('editable-ticket', {
    viewModel: require('./EditableTicketViewModel'),
    template: require('./EditableTicketTemplate.html')
});