class FooterViewModel {
    public date: string;

    constructor() {
        this.date = new Date().getFullYear().toString();
    }
}

export = FooterViewModel;