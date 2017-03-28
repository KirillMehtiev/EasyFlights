import { IAutocompleteOptions } from "./IAutocompleteOptions";
import Item = require("./AutocompleteItem");

class AutocompleteViewModel {
    public searchItem: KnockoutObservable<Item.AutocompleteItem>;
    public direction: string;
    public placeholder: string;
    public sourceUrl: string;

    constructor(options: IAutocompleteOptions) {
        this.searchItem = options.searchItem;
        this.direction = options.direction;
        this.placeholder = options.placeholder;
        this.sourceUrl = options.sourceUrl;
    }
}

export = AutocompleteViewModel;