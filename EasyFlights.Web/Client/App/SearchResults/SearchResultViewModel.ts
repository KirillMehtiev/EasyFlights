import ko = require("knockout");
import { FlightItem } from "./FlightResults/FlightItem";
import Item = require("./FlightResults/Tickets/TicketItem");
import TicketItem = Item.TicketItem;

class SearchResultViewModel {

    public flightItems: KnockoutObservableArray<FlightItem>;
    public pagedFlightItems: KnockoutObservableArray<FlightItem>;

    public pageSize: number;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: number;
    public maxPages: number;
    public directions: boolean;
    public boundary: boolean;
    public text: any;

    constructor() {
        this.flightItems = ko.observableArray(
            [new FlightItem(12, "Flight", "Country", "Economy", "13:30", [new TicketItem(12, "Flight", "Country", "Economy", "rtt", "13:30", "City", "2 h 20 min", "15:50", "145")]),
                new FlightItem(12, "Flight", "Country", "Lux", "14:30", [new TicketItem(13, "Flight", "Country", "Lux", "rtt", "14:30", "City", "2 h 30 min", "15:50", "145")]),
                new FlightItem(12, "Flight", "Country", "Economy", "15:30", [new TicketItem(14, "Flight", "Country", "Economy", "rtt", "15:30", "City", "2 h 40 min", "15:50", "145")])],
        );

        this.createDefaultOptions();
        this.setPage();
    }

    public setPage(): void {
        this.pagedFlightItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;

        var pagedFlightItems = this.flightItems.slice(startIndex, endIndex)

        for (var i = 0; i < pagedFlightItems.length; i++) {
            this.pagedFlightItems.push(pagedFlightItems[i]);
        }
    };

    private createDefaultOptions(): void {
        this.pagedFlightItems = ko.observableArray([]);
        this.pageNo = ko.observable(1);
        this.pageSize = 2;
        this.total = this.flightItems().length;
        this.maxPages = 5;
        this.directions = true;
        this.boundary = true;
        this.text = {
            first: 'First',
            last: 'Last',
            back: '«',
            forward: '»'
        };
    }
}

export = SearchResultViewModel;