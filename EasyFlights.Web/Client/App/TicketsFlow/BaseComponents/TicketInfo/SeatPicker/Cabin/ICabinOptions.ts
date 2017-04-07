import { RowItem } from "../SeatPickerItems/RowItem";

export interface ICabinOptions {
    seatNumber: KnockoutObservable<number>;
    rows: KnockoutObservableArray<RowItem>;
    columnsNames: KnockoutObservableArray<string>;
    rowsCount: number;
    selectNumber: KnockoutObservable<number>;
    seatChosen: KnockoutObservableArray<number>;
    firstName: string;
}