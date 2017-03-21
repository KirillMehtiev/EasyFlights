import ko = require("knockout");
ko.components.register('app-search-header', {
    viewModel: require('./SearchHeaderViewModel'),
    template: require('./SearchHeaderTemplate.html')
});