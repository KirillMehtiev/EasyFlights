import ko = require("knockout");

ko.components.register('account', {
    viewModel: require('./AccountViewModel'),
    template: require('./AccountTemplate.html')
});