import ko = require("knockout");

ko.components.register('app-footer', {
    viewModel: require('./FooterViewModel'),
    template: require('./FooterTemplate.html')
});