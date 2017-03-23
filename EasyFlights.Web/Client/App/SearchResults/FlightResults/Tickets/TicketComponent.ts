import ko = require("knockout");
ko.components.register('tickets', {
    viewModel: require('./TicketViewModel'),
    template: require('./TicketTemplate.html')
});