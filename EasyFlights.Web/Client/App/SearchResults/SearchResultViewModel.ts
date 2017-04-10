import ko = require("knockout");
import { RouteItem } from "./FlightResults/RouteItem";
import { RoutesService } from "./Services/RoutesService"
import { FlightItem } from "./FlightResults/Tickets/FlightItem"
import Service = require("../Common/Services/dataService");
import moment = require("moment");
import { DataService } from "../Common/Services/dataService";

class SearchResultViewModel {

    public routeItems: KnockoutObservableArray<RouteItem>;
    public pagedRouteItems: KnockoutObservableArray<RouteItem>;
    public departureDate: KnockoutObservable<Date>;
    public arrivalPlace: KnockoutObservable<string>;
    public arrivalPlaceId: KnockoutObservable<number>;
    public departurePlace: KnockoutObservable<string>;
    public departurePlaceId: KnockoutObservable<number>;
    public returnDate: KnockoutObservable<string>;
    public numberOfPassenger: KnockoutObservable<number>;
    public type: KnockoutObservable<string>;
    public dataService: DataService = new DataService();

    public headerSearchResult: KnockoutObservable<string>;

    public pageSize: KnockoutObservable<number>;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: KnockoutObservable<number>;
    public maxPages: KnockoutObservable<number>;
    public directions: KnockoutObservable<boolean>;
    public boundary: KnockoutObservable<boolean>;
    public text: any;

    public isLoading: KnockoutObservable<boolean>;
    public isRequestProcessing: KnockoutObservable<boolean>;

    private routesService: RoutesService = new RoutesService();

    constructor(params) {
        this.routeItems = ko.observableArray([]);
        this.departureDate = params.departureDate;
        this.arrivalPlace = params.arrivalPlace;
        this.arrivalPlaceId = params.arrivalPlaceId;
        this.departurePlaceId = params.departurePlaceId;
        this.departurePlace = params.departurePlace;
        this.returnDate = params.returnDate;
        this.numberOfPassenger = params.numberOfPassenger;
        this.type = params.type;

        this.createDefaultOptions();
        this.sortByPrice();
        this.isRequestProcessing = ko.observable(false);
        this.isLoading = ko.observable(true);
        this.headerSearchResult = ko.observable("");
        let url: string = this.createGetRoutesUrl();

        this.isRequestProcessing(true);
        this.routesService.getRoutes(url)
            .then((data) => {
                this.routeItems(data);
                this.isLoading(false);
                this.setPage();
                this.isRequestProcessing(false);
                this.headerSearchResult(this.routeItems().length + " Flights from " + this.departurePlace() + " to " + this.arrivalPlace() + " on " + this.departureDate() + " for " + this.numberOfPassenger() + " passenger(s)");
            }).fail((error) => {
                this.isLoading(false);
                this.isRequestProcessing(false);

            });

    }

    public setPage(): void {
        this.pagedRouteItems.removeAll();
        this.total = ko.observable((this.routeItems().length + this.pageSize() - 1) / this.pageSize());

        var startIndex = (this.pageNo() - 1) * this.pageSize();
        var endIndex = this.pageNo() * this.pageSize();

        var pagedFlightItems = this.routeItems().slice(startIndex, endIndex);
        ko.utils.arrayPushAll<RouteItem>(this.pagedRouteItems, pagedFlightItems);
    };

    public sortByPrice(): void {
        this.routeItems.sort((x, y) => x.totalCoast - y.totalCoast);
        this.setPage();
    }
    public sortByDuration(): void {
        this.routeItems.sort((x, y) => y.totalTime.split(':').reduce((seconds, v) => +v + seconds * 60, 0) / 60 -
            x.totalTime.split(':').reduce((seconds, v) => +v + seconds * 60, 0) / 60);
        this.setPage();
    }
    private createDefaultOptions(): void {
        this.pagedRouteItems = ko.observableArray([]);
        this.pageNo = ko.observable(1);
        this.pageSize = ko.observable(5);
        this.total = ko.observable(this.routeItems().length);
        this.maxPages = ko.observable(5);
        this.directions = ko.observable(true);
        this.boundary = ko.observable(true);
        this.text = {
            first: ko.observable('First'),
            last: ko.observable('Last'),
            back: ko.observable('«'),
            forward: ko.observable('»')
        };
    }

    private createGetRoutesUrl(): string {

        let result: string;
        result = `GetAsync?departureAirportId=${this.departurePlaceId()}&destinationAirportId=${this.arrivalPlaceId()}&numberOfPeople=${this.numberOfPassenger()}&departureTime=${moment(this.departureDate()).toISOString()}`;

        if (this.returnDate()) {
            result += `&returnTime=${moment(this.returnDate()).toISOString()}`;
        }
        return result;
    }
}
export = SearchResultViewModel;