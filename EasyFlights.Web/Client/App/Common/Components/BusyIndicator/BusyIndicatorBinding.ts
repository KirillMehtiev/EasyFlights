import $ = require("jquery");
require("blockUI");

import BusyIndicatorViewModel = require("./BusyIndicatorViewModel");

class BusyIndicatorBinding implements KnockoutBindingHandler {
    public init(element: any, valueAccessor: any, allBindingsAccessor: KnockoutAllBindingsAccessor, viewModel: BusyIndicatorViewModel): void {

        viewModel.isVisible.subscribe(() => {
            if (viewModel.isVisible()) {

                // for more information see http://jquery.malsup.com/block/
                $.blockUI({
                    message: "",
                    focusInput: false,
                    overlayCSS: {
                        backgroundColor: '#000',
                        opacity: 0.6,
                        cursor: 'default'
                    }
                });
            }
            else {
                $.unblockUI();
            }
        });
    }
}

export = BusyIndicatorBinding;