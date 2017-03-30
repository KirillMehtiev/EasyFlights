import Item  =  require("./SeatItem");
import RowOptions = require("./IRowOptions");

export class RowItem {
    public rowNumber: number;
    public seatsPerRow: number;
    public seats: KnockoutObservableArray<Item.SeatItem>;

    constructor(options: RowOptions.IRowOptions) {
        this.rowNumber = options.rowNumber;
        this.seats = options.seats;
        this.seatsPerRow = options.seatsPerRow;
    }

    public updateSeate(seatNumber: number, isChosen: boolean): void {
        let seat = this.seats()[seatNumber];
        seat.isChosen = isChosen;
    }    
}