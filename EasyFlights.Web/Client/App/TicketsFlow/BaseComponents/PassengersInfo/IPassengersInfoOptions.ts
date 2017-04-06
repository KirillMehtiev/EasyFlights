import { IInternalNavigation } from "../../IInternalNavigation";
import { IEditablePassengerOptions } from "./EditablePassenger/IEditablePassengerOptions";

export interface IPassengersInfoOptions extends IInternalNavigation {
    passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
}