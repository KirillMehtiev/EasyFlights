import ko = require("knockout");

ko.components.register('ticket', {
    viewModel: require('./TicketViewModel'),
    template: require('./TicketTemplate.html')
});