import { DataService } from '../../Common/Services/dataService';
import { IPassengerInfoItem } from "../PassengerInfo/IPassengerInfoItem";
import { TicketInfoGeneral } from "../TicketInfo/TicketInfo";

export class SelectFlowService {
    private apiBasePath = "api/Tickets";
    private dataService: DataService = new DataService();

    public getPassengerInfo(url: string): JQueryPromise<Array<IPassengerInfoItem>> {
        return this.dataService.get<Array<IPassengerInfoItem>>(this.apiBasePath + '/' + url);
    }

    public getTicketInfo(url: string, routeId: string, passengerInfo: Array<IPassengerInfoItem>): JQueryPromise<Array<TicketInfoGeneral>> {
        console.log("GetTickInfo");
        return this.dataService.post<Array<TicketInfoGeneral>>(this.apiBasePath + '/' + url, { routeId: routeId, passengers: passengerInfo });
    }
}