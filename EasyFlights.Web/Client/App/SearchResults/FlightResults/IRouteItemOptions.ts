import { RouteItem } from "./RouteItem";

export interface IRouteItemOptions {
    item: RouteItem;
    quantity: KnockoutObservable<number>; 
    
}