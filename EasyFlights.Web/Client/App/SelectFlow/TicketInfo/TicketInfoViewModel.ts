import {TicketInfoItem} from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import {RadioChooserItem} from "../../Common/Components/RadioChooser/RadioChooserItem";

class TicketInfoViewModel {
    public item: TicketInfoItem;
    public passengers: KnockoutObservableArray<PassengerInfoItem>;
    public classType:Array<RadioChooserItem>;

    constructor(options: ITicketInfoItemOptions) {
        this.passengers = options.passengers;
        this.classType = [
            new RadioChooserItem("Economy", "Economy"),
            new RadioChooserItem("Business", "Business"),
            new RadioChooserItem("First", "First")
        ];
    }    
}
export = TicketInfoViewModel;