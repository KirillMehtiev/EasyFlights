import ko = require("knockout");
import { RouteItem } from "./FlightResults/RouteItem";
import { SearchResultService } from "..//Common/Services/searchResultService"
import Item = require("./FlightResults/Tickets/FlightItem");
import FlightItem = Item.FlightItem;

class SearchResultViewModel {

    public routeItems: KnockoutObservableArray<RouteItem>;
    public pagedRouteItems: KnockoutObservableArray<RouteItem>;

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
        this.routeItems = ko.observableArray(
            [new RouteItem(12, "Flight", "Country", "Economy", "13:30", [new FlightItem(12, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145"), new FlightItem(13, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 350, 100),
                new RouteItem(12, "Flight", "Country", "Lux", "14:30", [new FlightItem(14, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 120, 400)]
                
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
        this.pagedRouteItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;

        var pagedFlightItems = this.routeItems.slice(startIndex, endIndex)

        for (var i = 0; i < pagedFlightItems.length; i++) {
            this.pagedRouteItems.push(pagedFlightItems[i]);
        }
    };

    public sortByPrice(): void {
        this.routeItems.sort((x, y) => x.totalCost - y.totalCost);
        this.setPage();
    }

    public sortByDuration(): void {
        this.routeItems.sort((x, y) => x.totalTime - y.totalTime);
        this.setPage();

        this.template();
    }

    private createDefaultOptions(): void {
        this.pagedRouteItems = ko.observableArray([]);
        this.pageNo = ko.observable(1);
        this.pageSize = 2;
        this.total = this.routeItems().length;
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