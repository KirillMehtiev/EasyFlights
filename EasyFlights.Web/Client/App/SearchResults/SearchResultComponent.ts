import ko = require("knockout");

ko.components.register('app-results', {
    viewModel: require('./SearchResultViewModel'),
    template: require('./SearchResultTemplate.html')
});