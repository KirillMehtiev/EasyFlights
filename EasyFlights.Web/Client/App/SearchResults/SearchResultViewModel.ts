﻿import ko = require("knockout");
import { RouteItem } from "./FlightResults/RouteItem";
import { RoutesService } from "./Services/RoutesService"
import { FlightItem } from "./FlightResults/Tickets/FlightItem"
import Service = require("../Common/Services/dataService");
import moment = require("moment");

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

    public pageSize: number;
    public pageNo: KnockoutObservable<number>;
    public pageIndex: any;
    public total: number;
    public maxPages: number;
    public directions: boolean;
    public boundary: boolean;
    public text: any;

    public isLoading: KnockoutObservable<boolean>;

    private routesService: RoutesService = new RoutesService();

    constructor(params) {
        console.log("Params: ",params);

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
        this.setPage();
        this.sortByPrice();

        this.isLoading = ko.observable(true);

        let url: string = this.createGetRoutesUrl();

        this.routesService.getRoutes(url)
            .then((data) => {
                this.routeItems(data);
                this.isLoading(false);
                this.setPage();
            }).fail((error) => {
                this.isLoading(false);
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
        $(".sortByPrice").removeClass('btn btn-default').addClass('btn btn-primary');
        $(".sortByDuration").removeClass('btn btn-primary').addClass('btn btn-default');
    }
    public sortByDuration(): void {
        this.routeItems.sort((x, y) => y.totalTime.split(':').reduce((seconds, v) => +v + seconds * 60, 0) / 60 -
                                       x.totalTime.split(':').reduce((seconds, v) => +v + seconds * 60, 0) / 60);
        this.setPage();
        $(".sortByDuration").removeClass('btn btn-default').addClass('btn btn-primary');
        $(".sortByPrice").removeClass('btn btn-primary').addClass('btn btn-default');
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

        let result: string;
        result = `GetAsync?departureAirportId=${this.departurePlaceId()}&destinationAirportId=${this.arrivalPlaceId()}&numberOfPeople=${this.numberOfPassenger()}&departureTime=${moment(this.departureDate()).toISOString()}`;

        if (moment(this.returnDate()).toISOString() != null) {

            result += `&returnTime=${moment(this.returnDate()).toISOString()}`;
        }
        return result;
    }
}
export = SearchResultViewModel;