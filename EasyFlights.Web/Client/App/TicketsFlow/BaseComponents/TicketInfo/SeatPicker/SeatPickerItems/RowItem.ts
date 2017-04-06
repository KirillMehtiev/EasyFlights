import Item  =  require("./SeatItem");

export class RowItem {
    public rowNumber: number;
    public seats: KnockoutObservableArray<Item.SeatItem>;

    constructor(rowNumber: number, seats: KnockoutObservableArray<Item.SeatItem>) {
        this.rowNumber = rowNumber;
        this.seats = seats;
    }

    public updateSeat(seatNumber: number, isChosen: boolean): void {
        let seat = this.seats()[seatNumber];
        seat.isChosen(isChosen);
    }    
}