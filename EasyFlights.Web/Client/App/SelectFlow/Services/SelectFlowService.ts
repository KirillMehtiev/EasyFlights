import { DataService } from '../../Common/Services/dataService';
import { PassengerInfoItem } from "../PassengerInfo/PassengerInfoItem";

export class SelectFlowService {
    private apiBasePath = "api/Tickets";
    private dataService: DataService = new DataService();

    public getPassengerInfo(url: string): JQueryPromise<Array<PassengerInfoItem>> {
        return this.dataService.get<Array<PassengerInfoItem>>(this.apiBasePath + '/' + url);
    }
}