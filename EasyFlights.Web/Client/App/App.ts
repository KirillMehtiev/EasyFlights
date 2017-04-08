import ko = require("knockout");
import validation = require("knockout.validation");
import pager = require("pager");

require("knockstrap");
require("jquery-ui");
import "./Components";
import "./ValidationRules";
import "./Bindings";
import './App.scss';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-datepicker/dist/css/bootstrap-datepicker.css';
import 'toastr/build/toastr.css';
import 'sweetalert/dist/sweetalert.css';

import KnockoutValidationOptions = require("./Validation/KnockoutValidationOptions");

class Application {
    public run(): void {
        pager.extendWithPage(this);
        ko.applyBindings(this);
        validation.init(new KnockoutValidationOptions(), true);
        validation.registerExtenders();

        window.setTimeout(function() {
            pager.start();
        });

    }
}
let application: Application = new Application();
application.run();
