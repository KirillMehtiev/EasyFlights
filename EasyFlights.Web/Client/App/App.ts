import ko = require("knockout");
import pager = require("pager");
import knockstrap = require("knockstrap");
import jqueryui = require("jquery-ui");
require('jquery-ui'); 
import "./Components";
import './App.scss';

class Application {
    public run(): void {
        pager.extendWithPage(this);
        ko.applyBindings(this);
        pager.start();
    }
}
let application: Application = new Application();
application.run();