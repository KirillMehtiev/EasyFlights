import ko = require("knockout");

ko.components.register('sorting', {
    viewModel: require('./SortingViewModel'),
    template: require('./SortingTemplate.html')
});