import ko = require("knockout");

ko.components.register('select-flow', {
    viewModel: require('./SelectFlowViewModel'),
    template: require('./SelectFlowTemplate.html')
});