import ko = require("knockout");
import { RouteItem } from "./FlightResults/RouteItem";
import { RoutesService } from "..//Common/Services/RoutesService"
import Item = require("./FlightResults/Tickets/FlightItem");
import FlightItem = Item.FlightItem;

class SearchResultViewModel {

    public routeItems: KnockoutObservableArray<RouteItem>;
    public pagedRouteItems: KnockoutObservableArray<RouteItem>;

    public pageSize: number;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: number;
    public maxPages: number;
    public directions: boolean;
    public boundary: boolean;
    public text: any;

    private routesService: RoutesService = new RoutesService();

    constructor() {
        this.routeItems = ko.observableArray(
            [new RouteItem(12, "Flight", "Country", "Economy", "13:30", [new FlightItem(12, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145"), new FlightItem(13, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 350, 100),
            new RouteItem(12, "Flight", "Country", "Lux", "14:30", [new FlightItem(14, "Borispol", "Kharkiv Airport", "14:00", "13:30", "2 h 20 min", "145")], 120, 400)]

        );

        this.createDefaultOptions();
        this.setPage();
        this.sortByPrice();
    }

    public setPage(): void {
        this.pagedRouteItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;

        var pagedFlightItems = this.routeItems.slice(startIndex, endIndex);

        ko.utils.arrayPushAll<RouteItem>(this.pagedRouteItems, pagedFlightItems);
    };

    public sortByPrice(): void {
        this.routeItems.sort((x, y) => x.totalCost - y.totalCost);
        this.setPage();
    }

    public sortByDuration(): void {
        this.routeItems.sort((x, y) => x.totalTime - y.totalTime);
        this.setPage();
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