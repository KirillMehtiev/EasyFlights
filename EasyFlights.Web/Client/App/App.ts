import ko = require("knockout");
import validation = require("knockout.validation");
import pager = require("pager");
import knockstrap = require("knockstrap");
import jqueryui = require("jquery-ui");
require('jquery-ui'); 
import "./Components";
import "./ValidationRules";
import "./Bindings";
import './App.scss';
import KnockoutValidationOptions = require("./Validation/KnockoutValidationOptions");

class Application {
    public run(): void {
        pager.extendWithPage(this);
        ko.applyBindings(this);
        validation.init(new KnockoutValidationOptions(), true);
        validation.registerExtenders();
        pager.start();
    }
}
let application: Application = new Application();
application.run();