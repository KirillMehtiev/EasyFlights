import ko = require("knockout");

ko.components.register('ticket-info', {
    viewModel: require('./TicketInfoViewModel'),
    template: require('./TicketInfoTemplate.html')
});