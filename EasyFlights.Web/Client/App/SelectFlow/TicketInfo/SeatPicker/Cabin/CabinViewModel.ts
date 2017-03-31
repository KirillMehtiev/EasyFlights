import {RowItem} from "../RowItem";
import CabinOptions = require("./ICabinOptions");

class CabinViewModel {
    public rows: KnockoutObservableArray<RowItem>;
    public rowsCount: number;
    public selectNumber: KnockoutObservable<number>;
    public isBlockSelect: KnockoutObservable<boolean>;

    constructor(options: CabinOptions.ICabinOptions) {
        this.rows = options.rows;
        this.rowsCount = options.rowsCount;
        this.selectNumber = options.selectNumber;
        this.isBlockSelect = ko.observable<boolean>(false);
    }

    public updateSeat(rowNumber: number, seatNumber: number, isChosen: boolean): void {
        this.rows()[rowNumber].updateSeate(seatNumber, isChosen);
    }  

    public onSelectSeat(): void {
        var previousCount = this.selectNumber();
        this.selectNumber = ko.observable(previousCount - 1);
        console.log(this.selectNumber());
        if (this.selectNumber() < 1) {
            this.isBlockSelect(true);
        }

        console.log(this.isBlockSelect());
    }
}

export = CabinViewModel;