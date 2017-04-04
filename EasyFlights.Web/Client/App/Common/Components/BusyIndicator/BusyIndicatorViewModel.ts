import $ = require("jquery");
require("blockUI");
import { IBusyIndicatorOptions } from "./IBusyIndicatorOptions";

class BusyIndicatorViewModel {

    public isVisible: KnockoutObservable<boolean>;

    constructor(options: IBusyIndicatorOptions) {
        this.isVisible = options.isLoading;
        this.isVisible.subscribe(this.onVisibleChanges, this);
    }

    private onVisibleChanges(): void {
        if (this.isVisible()) {

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
    }
}

export = BusyIndicatorViewModel;