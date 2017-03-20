import ko = require("knockout");

ko.components.register('radio-chooser', {
    viewModel: require('./RadioChooserViewModel'),
    template: require('./RadioChooserTemplate.html')
});