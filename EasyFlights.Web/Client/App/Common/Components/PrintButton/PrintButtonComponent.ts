import ko = require("knockout");

ko.components.register('print-button', {
    viewModel: require('./PrintButtonViewModel'),
    template: require('./PrintButtonTemplate.html')
});