import ko = require("knockout");

ko.components.register('date-picker', {
    viewModel: require('./DatePickerViewModel'),
    template: require('./DatePickerTemplate.html')
});