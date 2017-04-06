import { IInternalNavigation } from "../../IInternalNavigation";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

export interface ITicketInfoOptions extends IInternalNavigation {
    passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
}