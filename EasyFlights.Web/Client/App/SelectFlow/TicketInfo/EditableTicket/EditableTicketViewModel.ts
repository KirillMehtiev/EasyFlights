import { TicketClass } from "../../../Common/Enum/Enums";
import { IEditableTicketOptions } from "./IEditableTicketOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";

class EditableTicketViewModel {

    private static currentRadioChooserIndex: number = 0;
    private static ticketClassOptions: Array<RadioChooserItem> = [
        new RadioChooserItem("Economy", TicketClass.Economy.toString()),
        new RadioChooserItem("Business", TicketClass.Business.toString())
    ];

    public seat: KnockoutObservable<number>;
    public radioChooserIndex: number;

    constructor(options: IEditableTicketOptions) {
        console.log("Hello from editable-ticket");
        console.log(options);

        this.seat = options.seat;

        this.radioChooserIndex = ++EditableTicketViewModel.currentRadioChooserIndex;
    }
}

export = EditableTicketViewModel;