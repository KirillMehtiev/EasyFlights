import ko = require("knockout");

export class ToDoListItem {
    public text: KnockoutObservable<string>;
    public id: number;

    constructor(text: string, id: number) {
        this.text = ko.observable(text);
        this.id = id;
    }
}