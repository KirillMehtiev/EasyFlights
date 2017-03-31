import ko = require("knockout");
import { RouteItem } from "./FlightResults/RouteItem";
import { RoutesService } from "./Services/RoutesService"
import Item = require("./FlightResults/Tickets/FlightItem");
import FlightItem = Item.FlightItem;
import Service = require("../Common/Services/dataService");
import moment = require("moment");

class SearchResultViewModel {
   
    public routeItems: KnockoutObservableArray<RouteItem>;
    public pagedRouteItems: KnockoutObservableArray<RouteItem>;
    public departureDate: KnockoutObservable<Date>;
    public arrivalPlace: KnockoutObservable<number>;
    public departurePlace: KnockoutObservable<number>;
    public returnDate: KnockoutObservable<string>;
    public countOf: KnockoutObservable<number>;
    public type: KnockoutObservable<string>;

    public pageSize: number;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: number;
    public maxPages: number;
    public directions: boolean;
    public boundary: boolean;
    public text: any;

    public isLoading: KnockoutObservable<boolean>;
    public isError: KnockoutObservable<boolean>;

    private routesService: RoutesService = new RoutesService();

    constructor(params) {
        this.routeItems = ko.observableArray([]);
        this.departureDate = params.departureDate;
        this.arrivalPlace = params.arrivalPlace;
        this.departurePlace = params.departurePlace;
        this.returnDate = params.returnDate;
        this.countOf = params.countOf;
        this.type = params.type;

        this.createDefaultOptions();
        this.setPage();
        this.sortByPrice();

        this.isLoading = ko.observable(true);
        this.isError = ko.observable(false);

        let url: string = this.createGetRoutesUrl();

        this.routesService.getRoutes(url)
            .then((data) => {
                this.routeItems(data);
                this.isLoading(false);
                this.isError(false);
            }).fail((error) => {
                this.isLoading(false);
                this.isError(true);
            });
    }

    public setPage(): void {
        this.pagedRouteItems.removeAll();
        var startIndex = (this.pageNo() - 1) * this.pageSize;
        var endIndex = this.pageNo() * this.pageSize;

        var pagedFlightItems = this.routeItems.slice(startIndex, endIndex);

        ko.utils.arrayPushAll<RouteItem>(this.pagedRouteItems, pagedFlightItems);
    };

    public sortByPrice(): void {
        this.routeItems.sort((x, y) => x.totalCoast - y.totalCoast);
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

    private createGetRoutesUrl(): string {
        let resultUrl: string = "GetAsync?departureAirportId=4062&destinationAirportId=4068&numberOfPeople=1&departureTime=2017-03-24T13:05:17Z";

        //resultUrl = "GetAsync?departureAirportId" + this.departurePlace
        
        return resultUrl;
    }
}
export = SearchResultViewModel;