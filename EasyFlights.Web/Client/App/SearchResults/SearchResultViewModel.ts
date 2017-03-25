import ko = require("knockout");
import { FlightItem } from "./FlightResults/FlightItem";
import { SearchResultService } from "..//Common/Services/searchResultService"
import Item = require("./FlightResults/Tickets/TicketItem");
import TicketItem = Item.TicketItem;

class SearchResultViewModel {

    public flightItems: KnockoutObservableArray<FlightItem>;
    public pagedFlightItems: KnockoutObservableArray<FlightItem>;

    private apiBasePath = "api/Routes";
    public testString: string;

    public pageSize: number;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: number;
    public maxPages: number;
    public directions: boolean;
    public boundary: boolean;
    public text: any;

    private searchResultService: SearchResultService = new SearchResultService();

    constructor() {
        this.flightItems = ko.observableArray(
            [new FlightItem(12, "Flight", "Country", "Economy", "13:30", [new TicketItem(12, "Flight", "Country", "Economy", "rtt", "13:30", "City", "2 h 20 min", "15:50", "145")], 350, 100),
            new FlightItem(12, "Flight", "Country", "Lux", "14:30", [new TicketItem(13, "Flight", "Country", "Lux", "rtt", "14:30", "City", "2 h 30 min", "15:50", "145")], 120, 400),
            new FlightItem(12, "Flight", "Country", "Economy", "15:30", [new TicketItem(14, "Flight", "Country", "Economy", "rtt", "15:30", "City", "2 h 40 min", "15:50", "145")], 600, 200)],
        );

        this.createDefaultOptions();
        this.setPage();
        this.sortByPrice();
    }

    private template(): void {
        var country = this.searchResultService.getCountry();
        var country2 = this.searchResultService.takeCountry(country);
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

    public sortByPrice(): void {
        this.flightItems.sort((x, y) => x.totalCost - y.totalCost);
        this.setPage();
    }

    public sortByDuration(): void {
        this.flightItems.sort((x, y) => x.totalDuration - y.totalDuration);
        this.setPage();

        this.template();
    }

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