import ko = require("knockout");
ko.components.register('flights', {
    viewModel: require('./FlightViewModel'),
    template: require('./FlightTemplate.html')
});