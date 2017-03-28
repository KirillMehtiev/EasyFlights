export class DataService {

    public get<T>(url: string): JQueryPromise<T> {
        return $.getJSON(url)
            .then((data) => {
                return <T>data;
            })
            .fail(console.log);
    };

    public ajaxGet<T>(url: string): JQueryPromise<T> {
        return $.ajax({
            url: url,
            type: "GET",
            dataType: "json"
        }).then((data) => {
            return <T>data;
        }).fail(console.log);
    };

    public post<T>(url: string, data?: any): JQueryPromise<T> {
        return $.post(url, JSON.stringify(data))
            .then((data) => {
                if (data) {
                    return <T>data;
                }
            })
            .fail(console.log);
    };
}