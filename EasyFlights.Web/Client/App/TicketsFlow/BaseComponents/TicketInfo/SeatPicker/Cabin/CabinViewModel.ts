import { RowItem } from "../SeatPickerItems/RowItem";
import CabinOptions = require("./ICabinOptions");

class CabinViewModel {
    public rows: KnockoutObservableArray<RowItem>;
    public rowsCount: number;
    public columnsCount: number;
    public selectNumber: KnockoutObservable<number>;
    public isBlockSelect: KnockoutObservable<boolean>;
    public columnsNames: KnockoutObservableArray<string>;
    public seatNumber: KnockoutObservable<number>;
    public seatChosen: KnockoutObservableArray<number>;
    public firstName: string;

    constructor(options: CabinOptions.ICabinOptions) {
        this.rows = options.rows;
        this.rowsCount = options.rowsCount;
        this.selectNumber = options.selectNumber;
        this.seatNumber = options.seatNumber;
        this.isBlockSelect = ko.observable<boolean>(false);
        this.columnsNames = options.columnsNames;
        this.seatChosen = options.seatChosen;
        this.firstName = options.firstName;
        console.log(this.columnsNames());
    }

    public updateSeat(rowNumber: number, seatNumber: number, isChosen: boolean): void {
        this.rows()[rowNumber].updateSeat(seatNumber, isChosen);
    } 

    public chooseNumber(seatNumber: number) {
        this.rows().forEach(x => x.seats().forEach(z => (z.seat !== seatNumber) ? z.isChosen(false) : this.choose(seatNumber)));
    } 

    public choose(seatNumber: number) {
        this.seatChosen()[this.firstName] = seatNumber;
        this.seatNumber(seatNumber);
    }
}

export = CabinViewModel;