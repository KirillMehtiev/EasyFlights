import ko = require("knockout");

export class SearchHeaderItem {


    public destinationCity: KnockoutObservable<string>;
    public arrivalCity: KnockoutObservable<string>;
    public datetime: KnockoutObservable<string>

    constructor(destinationCity: string, arrivalCity: string, datetime: string) {

        this.destinationCity = ko.observable(destinationCity);
        this.arrivalCity = ko.observable(arrivalCity);
        this.datetime = ko.observable(datetime);
    }
}