import ko = require("knockout");
import Item = require("./SeatPickerItems/SeatItem");
import RowItem1 = require("./SeatPickerItems/RowItem");
import InfoItem = require("./SeatPickerItems/CabinInfoItem");
import Service = require("../../../../Common/Services/dataService");
import SeatPickerOptions = require("./ISeatPickerOptions");

class SeatPickerViewModel {

    public rows: KnockoutObservableArray<RowItem1.RowItem> = ko.observableArray<RowItem1.RowItem>(null);
    public cabin: KnockoutObservable<InfoItem.CabinInfoItem>;
    public rowsCount: KnockoutObservable<number>;
    public columnsNames: KnockoutObservableArray<string>;
    public seatNumber: KnockoutObservable<number>;
    public seatChosen: KnockoutObservableArray<number>;
    public firstName: KnockoutObservable<string>;
    public modalVisible: KnockoutObservable<boolean>;
    public modalSize: KnockoutObservable<string>;
    public bodyTemplate: KnockoutObservable<string>;
    public templateData: TemplateData;
    public bodyData: KnockoutComputed<TemplateData>;

    private dataService: Service.DataService = new Service.DataService();

    constructor(options: SeatPickerOptions.ISeatPickerOptions) {
        this.seatNumber = options.seatNumber;
        this.rowsCount = ko.observable<number>();
        this.columnsNames = ko.observableArray<string>();
        this.seatChosen = options.seatChosen;
        this.firstName = options.firstName;
        this.getSeatPickerInfo();
        this.modalVisible = ko.observable(false);
        this.modalSize = ko.observable('');
        this.templateData = {
            rows: this.rows,
            rowsCount: this.rowsCount,
            columnsNames: this.columnsNames,
            seatNumber: this.seatNumber,
            seatChosen: this.seatChosen,
            firstName: this.firstName()
    };
        this.bodyTemplate = ko.observable('modalTemplate');
        this.bodyData = ko.computed(() => this.templateData);
    }

    public getSeatPickerInfo() {
        this.dataService.get<InfoItem.CabinInfoItem>("api/Cabin/?flightId=1")
            .then((data) => this.cabin = ko.observable(data))
            .then(() => this.getColumnsNames());
    }

    public show(): void {
        this.modalVisible(true);
        this.loadSeatPicker();
    };

    public loadSeatPicker(): void {
        this.rows(new Array<RowItem1.RowItem>());
        for (let i = 0; i < this.cabin().seatsPerRow; i++) {
            const seatsperrow = ko.observableArray<Item.SeatItem>();
            const start = i * this.cabin().rowsCount + 1;
            const end = this.cabin().rowsCount * (i + 1);

            for (let j = start; j <= end; j++) {
                let isBooked = false;
                if (this.cabin().bookedSeats != undefined) {
                    if (this.cabin().bookedSeats().indexOf(j) !== -1) {
                        isBooked = true;
                    }
                }
                let isSelected = ko.observable(false);
                if (this.seatChosen()[this.firstName()] === j) {
                    isSelected(true);
                }
                var keys = Object.keys(this.seatChosen());
                for (var s = 0; s < keys.length; s++) {
                    if (this.firstName() != keys[s] && this.seatChosen()[keys[s]] === j) {
                        isBooked = true;
                    }
                }
                this.seatChosen().forEach(x=>(x!==-1)?isBooked=true:console.log(x));
              

               const isSpace = this.cabin().rowsCount * i + 3 === j;
               const item = new Item.SeatItem(i + 1, j, isSpace, ko.observable(isBooked), isSelected);
               seatsperrow.push(item);
            }

            const row = new RowItem1.RowItem(i + 1, seatsperrow);
            //For example
            if (i === 0) {
                row.seats()[3].isBooked = ko.observable(true);
            };

            this.rows.push(row);
        }
        
        this.rowsCount = ko.observable<number>(this.rows.length);
    }

    public getColumnsNames() {
        const columnsCount = this.cabin().rowsCount;
        const lang = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const result = lang.slice(0, columnsCount);
        for (var i = 0; i < result.length; i++) {
            this.columnsNames.push(result[i]);
        }

        this.columnsNames.splice(3, 0, "");
    }
}

class TemplateData {
    rows: KnockoutObservableArray<RowItem1.RowItem>;
    rowsCount: KnockoutObservable<number>;
    columnsNames: KnockoutObservableArray<string>;
    seatNumber: KnockoutObservable<number>;
    seatChosen: KnockoutObservableArray<number>;
    firstName: string;
}

export = SeatPickerViewModel;