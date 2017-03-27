import { DataService } from './dataService';
import { Country } from '..//Models/country'

export class SearchResultService {
    private apiBasePath = "api/Routes";
    public dataService: DataService = new DataService();

    public getCountry(): any {
        return this.dataService.get<Country>(this.apiBasePath + "/GetCountry").then((data) => console.log(data));
    }

    public takeCountry(country: Country): any {
        return this.dataService.post<Country>(this.apiBasePath + "/TakeCountry", country).then((data) => console.log(data));;
    }
}