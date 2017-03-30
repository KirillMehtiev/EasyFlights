import Item = require("./RowItem");

export interface ICabinOptions {
    rows: KnockoutObservable<Item.RowItem>;
    rowsCount: number;
}