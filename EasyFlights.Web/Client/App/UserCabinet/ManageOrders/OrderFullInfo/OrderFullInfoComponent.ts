import ko = require("knockout");

ko.components.register('order-full-info', {
    viewModel: require('./OrderFullInfoViewModel'),
    template: require('./OrderFullInfoTemplate.html')
});