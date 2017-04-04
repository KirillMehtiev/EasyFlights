export class SeatItem {
    public row: number;
    public seat: number;
    public isSpace: KnockoutObservable<boolean>;
    public isBooked: KnockoutObservable<boolean>;
    public isChosen: KnockoutObservable<boolean>; 

    constructor(row: number, seat: number, isSpace: boolean, isBooked: KnockoutObservable<boolean>, isChosen: KnockoutObservable<boolean>) {
        this.row = row;
        this.seat = seat;
        this.isSpace = ko.observable<boolean>(isSpace);
        this.isBooked = isBooked;
        this.isChosen = isChosen;
    }

    public updateSeat() {
        let value = !this.isChosen();
        this.isChosen(value);
    };
}