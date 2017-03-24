import { TicketItem } from "./TicketItem"
import { ITicketOptions } from "./ITicketOptions"

class TicketViewModel {


    public item: TicketItem;

    constructor(options: ITicketOptions) {
        this.item = options.item;

    }

}

export = TicketViewModel