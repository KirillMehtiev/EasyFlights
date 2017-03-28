export interface IAutocompleteOptions {
    searchItem: KnockoutObservable<string>;
    sourceUrl: string; 
    direction: string;
    placeholder: string;
}