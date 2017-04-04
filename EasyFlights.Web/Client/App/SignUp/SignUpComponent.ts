import ko = require("knockout");

ko.components.register('sign-up', {
    viewModel: require('./SignUpViewModel'),
    template: require('./SignUpTemplate.html')
});