"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ko = require("knockout");
var ToDoListItem = (function () {
    function ToDoListItem(text, id) {
        this.text = ko.observable(text);
        this.id = id;
    }
    return ToDoListItem;
}());
exports.ToDoListItem = ToDoListItem;
