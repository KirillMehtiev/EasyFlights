import ko = require("knockout");

ko.components.register('route-header', {
    viewModel: require('./RouteHeaderViewModel'),
    template: require('./RouteHeaderTemplate.html')
});