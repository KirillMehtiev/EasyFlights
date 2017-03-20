import ko = require("knockout");

ko.components.register('about', {
    viewModel: require('./AboutViewModel'),
    template: require('./AboutTemplate.html')
});