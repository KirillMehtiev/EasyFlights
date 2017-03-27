export class DataService {

    private getData: any;
    public postData: any;

    public get<T>(url: string): JQueryPromise<T> {
        return $.getJSON(url)
            .then((data) => {
                return <T>data;
            })
            .fail((error) => console.log(error));
    }

    public post<T>(url: string, data?: any): JQueryPromise<T> {
        return $.post(url, JSON.stringify(data))
            .then((data) => {
                if (data)
                    return <T>data
            })
            .fail((error) => console.log(error));;
    }
}