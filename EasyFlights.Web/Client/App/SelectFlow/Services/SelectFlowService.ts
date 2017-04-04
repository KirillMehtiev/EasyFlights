import { DataService } from '../../Common/Services/dataService';

export class RoutesService {
    private apiBasePath = "api/Routes";
    private dataService: DataService = new DataService();

    //public getRoutes(url: string): JQueryPromise<Array<RouteItem>> {
    //    return this.dataService.get<Array<RouteItem>>(this.apiBasePath + '/' + url);
    //}

}