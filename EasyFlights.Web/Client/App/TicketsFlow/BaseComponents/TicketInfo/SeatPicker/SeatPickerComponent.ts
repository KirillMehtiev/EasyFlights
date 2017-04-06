import ko = require("knockout");
ko.components.register('seat-picker', {
    viewModel: require('./SeatPickerViewModel'),
    template: require('./SeatPicker.html')
});