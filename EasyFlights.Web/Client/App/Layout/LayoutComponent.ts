import ko = require("knockout");

ko.components.register('app-layout', {
    viewModel: require("./LayoutViewModel"),
    template: require("./LayoutTemplate.html")
});