import { RowItem } from "../SeatPickerItems/RowItem";

export interface ICabinOptions {
    rows: KnockoutObservableArray<RowItem>;
    columnsNames: KnockoutObservableArray<string>;
    rowsCount: number;
    selectNumber: KnockoutObservable<number>;
}