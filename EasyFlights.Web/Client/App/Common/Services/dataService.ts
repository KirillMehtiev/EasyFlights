import toastr = require('toastr');

export class DataService {

    public get<T>(url: string): JQueryPromise<T> {
        return $.getJSON(url)
            .then((data) => {
                return <T>data;
            })
            .fail((error) => {
                toastr.error("Error occurred while getting data");
            });
    }

    public post<T>(url: string, data?: any): JQueryPromise<T> {
        return $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8"
        }).fail(() => {
            toastr.error("Error occurred while posting data");
        });
    }
}