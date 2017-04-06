import ko = require("knockout");

ko.components.register('passengers-info', {
    viewModel: require('./PassengersInfoViewModel'),
    template: require('./PassengersInfoTemplate.html')
});