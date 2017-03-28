export class AutocompleteItem {
    public label: string;
    public value: string;
    public id: string;

    constructor(label: string, value: string, id: string) {
        this.label = label;
        this.value = value;
        this.id = id;
    }
}