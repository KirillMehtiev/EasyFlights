import ko = require("knockout");

ko.components.register('profile-info', {
    viewModel: require('./ProfileInfoViewModel'),
    template: require('./ProfileInfoTemplate.html')
});