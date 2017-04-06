import ko = require("knockout");
import Service = require("../Common/Services/dataService");
import Item = require("./UserItem");

class UserCabinetViewModel {
    private dataService: Service.DataService = new Service.DataService();

    private firstName: KnockoutObservable<string>;
    private lastName: KnockoutObservable<string>;
    private contactPhone: KnockoutObservable<string>;
    private email: KnockoutObservable<string>;
    private sex: KnockoutObservable<string>;
    private dateOfBirth: KnockoutObservable<string>;

    private getUrl: string = "api/Account/GetUser";

    constructor() {
        
    }
    
}

export = UserCabinetViewModel;