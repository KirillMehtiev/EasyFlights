import ko = require("knockout");

ko.components.register('index', {
    viewModel: require('./IndexViewModel'),
    template: require('./IndexTemplate.html')
});