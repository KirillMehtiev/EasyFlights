import { IInternalNavigation } from "../../IInternalNavigation";
import { IEditablePassengerOptions } from "../PassengersInfo/EditablePassenger/IEditablePassengerOptions";

export interface IOrderSummaryOptions extends IInternalNavigation {
    passengerInfoList: KnockoutObservableArray<IEditablePassengerOptions>;
}