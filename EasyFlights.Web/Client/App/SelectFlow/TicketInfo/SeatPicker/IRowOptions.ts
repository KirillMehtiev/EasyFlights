import Item = require("./SeatItem");

export interface IRowOptions {
    seats: KnockoutObservableArray<Item.SeatItem>;
    seatsPerRow: number;
    rowNumber: number;
}