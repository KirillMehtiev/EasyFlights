import ko = require("knockout");

ko.components.register('user-cabinet', {
    viewModel: require('./UserCabinetViewModel'),
    template: require('./UserCabinetTemplate.html')
});