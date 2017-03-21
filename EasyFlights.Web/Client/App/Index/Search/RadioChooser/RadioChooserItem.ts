import ko = require("knockout");

export class RadioItem {
    label: KnockoutObservable<string>;
    value: KnockoutObservable<string>;

    constructor(label: string, value: string) {
        this.label = ko.observable(label);
        this.value = ko.observable(value);
    }
}