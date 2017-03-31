import { RowItem } from "../RowItem";

export interface ICabinOptions {
    rows: KnockoutObservableArray<RowItem>;
    rowsCount: number;
    selectNumber: KnockoutObservable<number>;
}