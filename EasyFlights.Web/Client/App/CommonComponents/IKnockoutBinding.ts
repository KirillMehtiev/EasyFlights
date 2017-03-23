export interface IKnockoutBinding {
    init(element: any, valueAccessor: any, allBindingsAccessor: any): void;
    update (element: any, valueAccessor: any): void;
}