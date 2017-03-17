import ko = require("knockout");
import { ILayoutOptions } from "./ILayoutOptions"

class LayoutViewModel {
    public title: KnockoutObservable<string>;

    constructor(options: ILayoutOptions) {
        this.title = ko.observable(options.title);
    }
}

export = LayoutViewModel