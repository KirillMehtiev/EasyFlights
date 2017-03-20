"use strict";
exports.__esModule = true;
var ko = require("knockout");
var ToDoListItem = (function () {
    function ToDoListItem(text, id) {
        this.text = ko.observable(text);
        this.id = id;
    }
    return ToDoListItem;
}());
exports.ToDoListItem = ToDoListItem;
//# sourceMappingURL=ToDoListItem.js.map