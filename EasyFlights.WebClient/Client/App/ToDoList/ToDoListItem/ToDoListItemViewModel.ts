import { ToDoListItem } from "./ToDoListItem"
import { IToDoListItemOptions } from "./IToDoListItemOptions"

class ToDoListViewModel {
    private onRemoveItem: KnockoutSubscribable<number>;

    public item: ToDoListItem;

    constructor(options: IToDoListItemOptions) {
        this.item = options.item;
        this.onRemoveItem = options.onRemoveItem;

        this.removeItem.bind(this);
    }

    public removeItem(): void {
        this.onRemoveItem.notifySubscribers(this.item.id);
    }
}

export = ToDoListViewModel