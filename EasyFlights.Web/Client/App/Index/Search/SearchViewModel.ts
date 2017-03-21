import ko = require("knockout");
import { RadioItem } from "./RadioChooser/RadioChooserItem";

class SearchViewModel {
    private options: Array<RadioItem>;

    public selectedTicketType: KnockoutObservable<string>;

    constructor() {
        this.options = [
            new RadioItem("One Way", "one-way"),
            new RadioItem("Round trip", "round-trip")
        ];
        this.selectedTicketType = ko.observable("one-way");
    }
}

export = SearchViewModel;