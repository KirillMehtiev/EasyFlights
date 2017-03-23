"use strict";
exports.__esModule = true;
var ko = require("knockout");
var CityItem = (function () {
    function CityItem(text, id) {
        this.text = ko.observable(text);
        this.id = id;
    }
    return CityItem;
}());
exports.CityItem = CityItem;
//# sourceMappingURL=CityItem.js.map