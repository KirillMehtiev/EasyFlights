import ko = require("knockout");
import Item = require("./SeatItem");
import RowItem1 = require("./RowItem");
import InfoItem = require("./CabinInfoItem");
import Service = require("../../../Common/Services/dataService");

class SeatPickerViewModel {

    public seats: KnockoutObservableArray<Item.SeatItem>;
    public rows: KnockoutObservableArray<RowItem1.RowItem> = ko.observableArray<RowItem1.RowItem>(null);
    public cabin: KnockoutObservable<InfoItem.CabinInfoItem>;
    public rowsCount: KnockoutObservable<number>;

    public modalVisible: KnockoutObservable<boolean>;
    public modalSize: KnockoutObservable<string>;
    public bodyTemplate: KnockoutObservable<string>;
    public templateData: TemplateData;
    public bodyData: KnockoutComputed<TemplateData>;
    private dataService: Service.DataService = new Service.DataService();

    constructor() {
        this.seats = ko.observableArray<Item.SeatItem>();
        this.rowsCount = ko.observable<number>(5);
        this.dataService.get<InfoItem.CabinInfoItem>("api/Cabin/?flightId=1")
            .then((data) => this.cabin = ko.observable(data)).then(() => this.loadSeatPicker());
        this.modalVisible = ko.observable(false);
        this.modalSize = ko.observable('modal-lg');
        this.templateData = {
            rows: this.rows,
            rowsCount: this.rowsCount
        };
        this.bodyTemplate = ko.observable('modalTemplate');
        this.bodyData = ko.computed(() => this.templateData);
    }

    public show(): void {
        this.modalVisible(true);
    };

    public loadSeatPicker(): void {
        for (var i = 0; i < this.cabin().rowsCount; i++) {
            let seatsperrow = ko.observableArray<Item.SeatItem>();
            for (var j = i * this.cabin().seatsPerRow + 1; j <= this.cabin().seatsPerRow * (i + 1); j++) {
                let isBooked = false;
                if (this.cabin().bookedSeats != undefined) {
                    if (this.cabin().bookedSeats().indexOf(j) !== -1) {
                        isBooked = true;
                    }
                }
                let item = new Item.SeatItem(i + 1, j, ko.observable(isBooked), ko.observable(false));
                this.seats.push(item);
                seatsperrow.push(item);
            }
            let row = new RowItem1.RowItem(i + 1, this.cabin().seatsPerRow, seatsperrow);
            if (i === 0) {
                row.seats()[3].isBooked = ko.observable(true);
            };
            this.rows.push(row);
        }
    }
}

class TemplateData {
    rows: KnockoutObservableArray<RowItem1.RowItem>;
    rowsCount: KnockoutObservable<number>;
}

export = SeatPickerViewModel;