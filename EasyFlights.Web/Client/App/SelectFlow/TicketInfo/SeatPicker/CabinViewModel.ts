import Item = require("./RowItem");
import CabinOptions = require("./ICabinOptions");

class CabinViewModel {
    public rows: KnockoutObservable<Item.RowItem>;
    public rowsCount: number;

    constructor(options: CabinOptions.ICabinOptions) {
        this.rows = options.rows;
        this.rowsCount = options.rowsCount;
    }

    public updateSeat(rowNumber: number, seatNumber: number, isChosen: boolean): void {
        let row = this.rows()[rowNumber];
        row.updateSeat(seatNumber, isChosen);
    }  
}

export = CabinViewModel;