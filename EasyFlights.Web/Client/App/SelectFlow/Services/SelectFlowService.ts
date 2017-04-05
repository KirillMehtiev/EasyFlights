import { DataService } from '../../Common/Services/dataService';
import { IPassengerInfoItem } from "../PassengerInfo/IPassengerInfoItem";

export class SelectFlowService {
    private apiBasePath = "api/Tickets";
    private dataService: DataService = new DataService();

    public getPassengerInfo(url: string): JQueryPromise<Array<IPassengerInfoItem>> {
        return this.dataService.get<Array<IPassengerInfoItem>>(this.apiBasePath + '/' + url);
    }
}