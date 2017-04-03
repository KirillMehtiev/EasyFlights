import ko = require("knockout");

ko.components.register('account', {
    viewModel: require('./Account'),
    template: require('./Account.html')
});