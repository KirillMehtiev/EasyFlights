import { TicketClass } from "../../../Common/Enum/Enums";
import { IEditableTicketOptions } from "./IEditableTicketOptions";
import { RadioChooserItem } from "../../../Common/Components/RadioChooser/RadioChooserItem";

class EditableTicketViewModel {

    private static currentRadioChooserIndex: number = 0;

    private ticketClassOptions: Array<RadioChooserItem>;

    public firstName: KnockoutObservable< string>;
    public lastName: KnockoutObservable<string>;
    public fare: KnockoutObservable<number>;
    public seat: KnockoutObservable<string>;
    public class: KnockoutObservable<TicketClass>;

    public radioChooserIndex: number;

    constructor(options: IEditableTicketOptions) {
        this.ticketClassOptions = [
            new RadioChooserItem("Economy", TicketClass.Economy.toString()),
            new RadioChooserItem("Business", TicketClass.Business.toString())
        ];

        console.log("Hello from editable-ticket");
        console.log(options);

        this.firstName = options.firstName;
        this.lastName = options.lastName;
        this.fare = options.fare;
        this.seat = options.seat;
        this.class = options.class;

    }
}

export = EditableTicketViewModel;