import {TicketInfoItem} from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

class TicketInfoViewModel {
    public item: TicketInfoItem;
    public passengers: KnockoutObservableArray<PassengerInfoItem>;
    public test: KnockoutObservable<string>;

    constructor(options: ITicketInfoItemOptions) {
        this.passengers = options.passengers;
    }    
}
export = TicketInfoViewModel;