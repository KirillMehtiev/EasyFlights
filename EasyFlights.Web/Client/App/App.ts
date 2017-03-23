import ko = require("knockout");
import validation = require("knockout.validation");
import pager = require("pager");
import knockstrap = require("knockstrap");
import jquery = require("jquery");
import "./Components";
import "./Validation/ValidationRules"
import './App.scss';

class Application {
    public run(): void {
        pager.extendWithPage(this);
        ko.applyBindings(this);
        validation.registerExtenders();
        pager.start();
    }
}
let application: Application = new Application();
application.run();