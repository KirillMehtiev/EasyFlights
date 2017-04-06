import ko = require("knockout");
import Service = require("../Common/Services/dataService");
import Item = require("./UserItem");
import UserItem = Item.UserItem;

class UserCabinetViewModel {

    private dataService: Service.DataService = new Service.DataService();

    private firstName: KnockoutObservable<string>;
    private lastName: KnockoutObservable<string>;
    private contactPhone: KnockoutObservable<string>;
    private email: KnockoutObservable<string>;
    private sex: KnockoutObservable<string>;
    private dateOfBirth: KnockoutObservable<string>;
    public user: KnockoutObservable<UserItem>;

    private getUrl: string = "api/Account/UserInfo";

    constructor() {
        this.user = ko.observable(new UserItem("","","","","",""));
        this.GetUser.bind(this);

   
        console.log(this.user().firstName);

    }

    public GetUser(): UserItem {
        this.dataService.get<UserItem>(this.getUrl)
            .then((data) => {
                this.user(data);

            });
        return this.user();
    }
    
    
}

export = UserCabinetViewModel;