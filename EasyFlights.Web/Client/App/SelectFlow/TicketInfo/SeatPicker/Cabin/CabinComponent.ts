import ko = require("knockout");
ko.components.register('cabin', {
    viewModel: require('./CabinViewModel'),
    template: require('./Cabin.html')
});