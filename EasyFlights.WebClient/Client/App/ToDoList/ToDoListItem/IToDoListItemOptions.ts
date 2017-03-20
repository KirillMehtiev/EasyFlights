import { ToDoListItem } from "./ToDoListItem";

export interface IToDoListItemOptions {
    item: ToDoListItem;
    onRemoveItem: KnockoutSubscribable<number>;
}