import { TicketClass } from "../../../Common/Enum/Enums";
import { IEditableTicketOptions } from "./IEditableTicketOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";

class EditableTicketViewModel {
    public seat: KnockoutObservable<number>;
    public radioChooserIndex: number;

    constructor(options: IEditableTicketOptions) {
        console.log("Hello from editable-ticket");
        console.log(options);

        this.seat = options.seat;
    }
}

export = EditableTicketViewModel;