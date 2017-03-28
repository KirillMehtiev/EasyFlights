"use strict";
exports.__esModule = true;
var ko = require("knockout");
var validation = require("knockout.validation");
var pager = require("pager");
require('jquery-ui');
require("./Components");
require("./ValidationRules");
require("./Bindings");
require("./App.scss");
require("bootstrap/dist/css/bootstrap.css");
require("bootstrap-datepicker/dist/css/bootstrap-datepicker.css");
var KnockoutValidationOptions = require("./Validation/KnockoutValidationOptions");
var Application = (function () {
    function Application() {
    }
    Application.prototype.run = function () {
        pager.extendWithPage(this);
        ko.applyBindings(this);
        validation.init(new KnockoutValidationOptions(), true);
        validation.registerExtenders();
        pager.start();
    };
    return Application;
}());
var application = new Application();
application.run();
//# sourceMappingURL=App.js.map