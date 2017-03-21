import ko = require("knockout");

ko.components.register('search', {
    viewModel: require('./SearchViewModel'),
    template: require('./SearchTemplate.html')
});