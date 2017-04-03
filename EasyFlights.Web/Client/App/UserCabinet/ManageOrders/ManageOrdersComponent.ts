import ko = require("knockout");

ko.components.register('manage-orders', {
    viewModel: require('./ManageOrdersViewModel'),
    template: require('./ManageOrdersTemplate.html')
});