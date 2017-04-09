class LazyPageViewModel {
    public departurePlace: string;
    public id: string;
    public guard: any;
    public params: string[];
    public pageVisible: KnockoutObservable<boolean>;

    constructor(params) {
        this.id = params.id;
        this.guard = params.guard;
        this.params = params.params;
        this.pageVisible = ko.observable(false);
        this.beforeShow.bind(this);
    }

    public onShow(callback, page): void {
        callback({});
    }

    public beforeShow(params): void {
        let pageId = params.page.currentId;

        // When go to ticket flow add event which add alert message
        // when user try to reload page to prevent data lost
        if (pageId === "selected-route" || pageId === "edit-tickets") {
            // todo: change this solution to addEventListener
            window.onbeforeunload = ev => {
                return "Any string value here forces a dialog box to \n" +
                    "appear before closing the window.";
            }
        }
    }

    public beforeHide(params): void {
        let pageId = params.page.currentId;
        if (pageId === "selected-route" || pageId === "edit-tickets") {
            // todo: change this solution to removeEventListener
            window.onbeforeunload = null;
        }
    }
}

export = LazyPageViewModel;