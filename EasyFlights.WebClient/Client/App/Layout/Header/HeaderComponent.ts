import ko = require("knockout");

ko.components.register('app-header', {
    viewModel: require('./HeaderViewModel'),
    template: require('./HeaderTemplate.html')
});