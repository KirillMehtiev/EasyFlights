export class SeatItem {
    public row: number;
    public seat: number;
    public isBooked: KnockoutObservable<boolean>;
    public isChosen: KnockoutObservable<boolean>; 

    constructor(row: number, seat: number, isBooked: KnockoutObservable<boolean>, isChosen: KnockoutObservable<boolean>) {
        this.row = row;
        this.seat = seat;
        this.isBooked = isBooked;
        this.isChosen = isChosen;
    }

    public updateSeat() {
        let value = !this.isChosen();
        this.isChosen(value);
    };
}