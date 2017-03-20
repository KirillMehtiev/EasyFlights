//interface IRadioOption {
//    value: string;
//    label: string;
//}

// TODO: add options, and user foreach for it

class RadioChooserViewModel {
    //public radioOptions: KnockoutObservableArray<IRadioOption>;
    public selectedOption: KnockoutObservable<string>;

    constructor() {
        let preselected: string = "one-way";

        //this.radioOptions = ko.observableArray([
        //    {
        //        label: "one-way",
        //        value: "One way"
        //    },
        //    {
        //        label: "rount-trip",
        //        value: "Round trip"
        //    }
        //]);

        this.selectedOption = ko.observable(preselected);
    }
}

export = RadioChooserViewModel;