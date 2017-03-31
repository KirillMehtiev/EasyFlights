import Item  =  require("./SeatItem");

export class RowItem {
    public rowNumber: number;
    public seatsPerRow: number;
    public seats: KnockoutObservableArray<Item.SeatItem>;

    constructor(rowNumber: number, seatsPerRow: number, seats: KnockoutObservableArray<Item.SeatItem>) {
        this.rowNumber = rowNumber;
        this.seats = seats;
        this.seatsPerRow = seatsPerRow;
    }

    public updateSeate(seatNumber: number, isChosen: boolean): void {
        let seat = this.seats()[seatNumber];
        seat.isChosen(isChosen);
    }    
}