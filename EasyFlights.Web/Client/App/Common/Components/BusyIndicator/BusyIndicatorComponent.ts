import ko = require("knockout");

ko.components.register('busy-indicator', {
    viewModel: require('./BusyIndicatorViewModel'),
    template: require('./BusyIndicatorTemplate.html')
});