"use strict";
var ToDoListViewModel = (function () {
    function ToDoListViewModel(options) {
        this.item = options.item;
        this.onRemoveItem = options.onRemoveItem;
        this.removeItem.bind(this);
    }
    ToDoListViewModel.prototype.removeItem = function () {
        this.onRemoveItem.notifySubscribers(this.item.id);
    };
    return ToDoListViewModel;
}());
module.exports = ToDoListViewModel;
//# sourceMappingURL=ToDoListItemViewModel.js.map