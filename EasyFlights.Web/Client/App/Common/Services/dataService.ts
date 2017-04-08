import toastr = require('toastr');

export class DataService {

    public get<T>(url: string): JQueryPromise<T> {
        return $.getJSON(url)
            .then((data) => {
                return <T>data;
            })
            .fail((error) => {
                this.showErrorMessage(error);
            });
    }

    public post<T>(url: string, data?: any): JQueryPromise<T> {
        return $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8"
        }).fail((error) => {
            this.showErrorMessage(error);
        });
    }

    public delete<T>(url: string): JQueryPromise<T> {
        return $.getJSON(url)
            .then((data) => {
                return <T>data;
            })
            .fail((error) => {
               this.showErrorMessage(error); 
            });
    }

    private showErrorMessage(error) {
        if (error.status !== 200) {
            let message: string = error.statusText;
            toastr.error(message, "Error", { timeOut: 5000 });
        }
    }
}