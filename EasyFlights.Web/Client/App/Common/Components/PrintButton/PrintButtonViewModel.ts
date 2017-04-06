class PrintButtonViewModel {
    constructor() {
        this.print.bind(this);
    }

    public print(): void {
        window.print();
    }
}

export = PrintButtonViewModel;