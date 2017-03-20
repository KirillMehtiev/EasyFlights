"use strict";
var ko = require("knockout");
var ToDoListItem_1 = require("./ToDoListItem/ToDoListItem");
var ToDoListViewModel = (function () {
    function ToDoListViewModel() {
        this.nextId = 1;
        this.todoItems = ko.observableArray([]);
        this.newItemText = ko.observable();
        this.onRemoveItem = new ko.subscribable();
        this.onRemoveItem.subscribe(this.removeItem, this);
        this.addNewItem.bind(this);
    }
    ToDoListViewModel.prototype.addNewItem = function () {
        this.todoItems.push(new ToDoListItem_1.ToDoListItem(this.newItemText(), this.nextId++));
        this.newItemText("");
    };
    ToDoListViewModel.prototype.removeItem = function (itemId) {
        this.todoItems.remove(function (item) { return item.id === itemId; });
    };
    return ToDoListViewModel;
}());
module.exports = ToDoListViewModel;
//# sourceMappingURL=ToDoListViewModel.js.map