import ko = require("knockout");

ko.components.register('sign-in', {
    viewModel: require('./LoginViewModel'),
    template: require('./LoginTemplate.html')
});