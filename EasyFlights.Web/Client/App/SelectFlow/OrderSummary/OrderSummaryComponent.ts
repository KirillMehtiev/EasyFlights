import ko = require("knockout");

ko.components.register('order-summary', {
    viewModel: require('./OrderSummaryViewModel'),
    template: require('./OrderSummaryTemplate.html')
});