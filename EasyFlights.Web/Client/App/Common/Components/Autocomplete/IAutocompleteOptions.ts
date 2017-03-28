import Item = require("./AutocompleteItem");

export interface IAutocompleteOptions {
    searchItem: KnockoutObservable<Item.AutocompleteItem>;
    sourceUrl: string; 
    direction: string;
    placeholder: string;
}