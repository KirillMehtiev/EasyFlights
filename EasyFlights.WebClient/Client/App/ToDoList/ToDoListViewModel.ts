import ko = require("knockout");
import { ToDoListItem } from "./ToDoListItem/ToDoListItem";

class ToDoListViewModel {
    public todoItems: KnockoutObservableArray<ToDoListItem>;
    public newItemText: KnockoutObservable<string>;
    public onRemoveItem: KnockoutSubscribable<number>;

    private nextId: number = 1;

    constructor() {
        this.todoItems = ko.observableArray([]);
        this.newItemText = ko.observable<string>();

        this.onRemoveItem = new ko.subscribable<number>();
        this.onRemoveItem.subscribe(this.removeItem, this);

        this.addNewItem.bind(this);
    }

    public addNewItem(): void {
        this.todoItems.push(new ToDoListItem(this.newItemText(), this.nextId++));
        this.newItemText("");
    }

    public removeItem(itemId: number): void {
        this.todoItems.remove(item => item.id === itemId);
    }
}

export = ToDoListViewModel