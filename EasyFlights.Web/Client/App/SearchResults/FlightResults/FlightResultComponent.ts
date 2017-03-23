import ko = require("knockout");
ko.components.register('flights', {
    viewModel: require('./FlightResultViewModel'),
    template: require('./FlightResult.html')
});