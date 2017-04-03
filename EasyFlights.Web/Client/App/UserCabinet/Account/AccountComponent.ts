import ko = require("knockout");

ko.components.register('Account', {
    viewModel: require('./Account'),
    template: require('./Account.html')
});