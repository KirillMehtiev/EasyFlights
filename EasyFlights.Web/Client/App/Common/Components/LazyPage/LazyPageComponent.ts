import ko = require("knockout");

ko.components.register('lazy-page', {
    viewModel: require('./LazyPageViewModel'),
    template: require('./LazyPageTemplate.html')
});