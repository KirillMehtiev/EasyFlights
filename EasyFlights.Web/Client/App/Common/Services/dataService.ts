export class DataService {

    private getData: any;
    public postData: any;

    public get<T>(url: string): T {
        $.getJSON(url, (data) => {
            this.getData = data;
        });
        return <T>this.getData;
    }

    public post(url: string, data?: any) {
        return $.post(url, JSON.stringify(data));
    }

    public postWithCallback<T>(url: string, data?: any): T {
        $.post(url, JSON.stringify(data), (data) => {
            this.postData = data;
        });
        return <T>this.postData;
    }
}