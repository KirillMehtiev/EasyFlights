import ko = require("knockout");

ko.components.register('order-tickets', {
    viewModel: require('./OrderTicketsViewModel'),
    template: require('../TicketsFlowTemplate.html')
});