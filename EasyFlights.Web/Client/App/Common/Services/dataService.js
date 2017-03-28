"use strict";
exports.__esModule = true;
var DataService = (function () {
    function DataService() {
    }
    DataService.prototype.get = function (url) {
        return $.getJSON(url)
            .then(function (data) {
            return data;
        })
            .fail(console.log);
    };
    DataService.prototype.ajaxGet = function (url) {
        return $.ajax({
            url: url,
            type: "GET",
            dataType: "json"
        }).then(function (data) {
            return data;
        }).fail(console.log);
    };
    DataService.prototype.post = function (url, data) {
        return $.post(url, JSON.stringify(data))
            .then(function (data) {
            if (data) {
                return data;
            }
        })
            .fail(console.log);
    };
    return DataService;
}());
exports.DataService = DataService;
//# sourceMappingURL=dataService.js.map