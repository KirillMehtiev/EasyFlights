import { ITicketsFlowOptions } from "../ITicketsFlowOptions";

export interface IOrderTicketsOptions extends ITicketsFlowOptions  {
    routeId: KnockoutObservable<string>;
    numberOfPassenger: KnockoutObservable<number>;
}