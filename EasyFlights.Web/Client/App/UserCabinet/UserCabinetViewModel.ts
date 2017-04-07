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
    public isRequestProcessing: KnockoutObservable<boolean>;

    private getUrl: string = "api/Account/UserInfo";

    constructor() {
        this.user = ko.observable(new UserItem("", "", "", "", "", ""));
        this.isRequestProcessing = ko.observable(false);
        this.getUser();

    }
    private getUser(): UserItem {
        this.isRequestProcessing(true);
        this.dataService.get<UserItem>(this.getUrl)
            .then((data) => {
                this.user(data);
            }).always(() => this.isRequestProcessing(false));;
        return this.user();

    } 
 
}

export = UserCabinetViewModel;