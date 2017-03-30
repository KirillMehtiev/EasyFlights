import {TicketInfoItem} from "./TicketInfoItem";
import { ITicketInfoItemOptions } from "./ITicketInfoItemOptions";
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";
import {RadioChooserItem} from "../../Common/Components/RadioChooser/RadioChooserItem";

class TicketInfoViewModel {
    public item: TicketInfoItem;
    constructor(options: ITicketInfoItemOptions) {        
    }    
}
export = TicketInfoViewModel;