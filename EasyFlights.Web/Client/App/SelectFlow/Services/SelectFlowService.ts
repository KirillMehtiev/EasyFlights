import { DataService } from '../../Common/Services/dataService';
import { TicketInfoGeneral } from "../TicketInfo/TicketInfo";

export class SelectFlowService {
    private apiBasePath = "api/Tickets";
    private dataService: DataService = new DataService();

    public getPassengerInfo(url: string): JQueryPromise<Array<any>> {
        //return this.dataService.get<Array<IPassengerInfoItem>>(this.apiBasePath + '/' + url);
        return null;
    }

    public getTicketInfo(url: string, routeId: string, passengerInfo: Array<any>): JQueryPromise<Array<TicketInfoGeneral>> {
        console.log("GetTickInfo");
        //return this.dataService.post<Array<TicketInfoGeneral>>(this.apiBasePath + '/' + url, { routeId: routeId, passengers: passengerInfo });
        return null;
    }
}