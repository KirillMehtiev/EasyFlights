export class SeatItem {
    public row: number;
    public seat: number;
    public isBooked: boolean;
    public isChosen: boolean; 

    constructor(row: number, seat: number, isBooked: boolean, isChosen: boolean) {
        this.row = row;
        this.seat = seat;
        this.isBooked = isBooked;
        this.isChosen = isChosen;
    }
}