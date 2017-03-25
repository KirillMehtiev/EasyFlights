import { DataService } from './dataService';
import { Country } from '..//Models/country'

export class SearchResultService {
    private apiBasePath = "api/Routes";
    public dataService: DataService = new DataService();

    public getCountry(): Country {
        return this.dataService.get<Country>(this.apiBasePath + "/GetCountry");
    }

    public takeCountry(country: Country): Country {
        return this.dataService.postWithCallback<Country>(this.apiBasePath + "/TakeCountry", country);
    }
}