import { DataService } from '../../Common/Services/dataService';

export class TicketsFlowService {
    private dataService: DataService = new DataService();

    public loadRoute(routeId: string): JQueryPromise<any> {
        return this.dataService.get("api/routes/getRouteById?routeId=" + routeId);
    }
}