import ko = require("knockout");
ko.components.register('routes', {
    viewModel: require('./RouteResultViewModel'),
    template: require('./RouteResult.html')
});