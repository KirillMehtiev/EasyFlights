import ko = require("knockout");

ko.components.register('edit-tickets', {
    viewModel: require('./EditTicketsViewModel'),
    template: require('../TicketsFlowTemplate.html')
});