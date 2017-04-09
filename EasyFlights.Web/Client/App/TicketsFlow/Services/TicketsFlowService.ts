import { DataService } from '../../Common/Services/dataService';
import { ITicketForBooking } from "./ITicketForBooking";
import { IEditablePassengerOptions } from "../BaseComponents/PassengersInfo/EditablePassenger/IEditablePassengerOptions";

export class TicketsFlowService {
    private dataService: DataService = new DataService();

    public loadRoute(routeId: string): JQueryPromise<any> {
        return this.dataService.get("api/routes/getRouteById?routeId=" + routeId);
    }

    public loadOrder(orderId: string): JQueryPromise<any> {
        return this.dataService.get("api/orders/getOrderForEdit?orderId=" + orderId);
    }

    public bookTickets(tickets: Array<ITicketForBooking>) {
        return this.dataService.post("api/orders/BookTickets", tickets);
    }
}