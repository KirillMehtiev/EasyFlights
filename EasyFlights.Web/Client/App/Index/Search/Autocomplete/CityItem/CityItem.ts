import ko = require("knockout");

export class CityItem {
    text: KnockoutObservable<string>;
    id: number;

    constructor(text: string, id: number) {
        this.text = ko.observable(text);
        this.id = id;
    }
}