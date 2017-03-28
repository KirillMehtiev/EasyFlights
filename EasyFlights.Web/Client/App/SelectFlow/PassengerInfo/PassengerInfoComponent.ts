import ko = require("knockout");

ko.components.register('passenger-info', {
    viewModel: require('./PassengerInfoViewModel'),
    template: require('./PassengerInfoTemplate.html')
});