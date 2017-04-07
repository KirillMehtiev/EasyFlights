import { ITicketsFlowOptions } from "../ITicketsFlowOptions";

export interface IEditTicketsOptions extends ITicketsFlowOptions  {
    orderId: KnockoutObservable<number>;
}