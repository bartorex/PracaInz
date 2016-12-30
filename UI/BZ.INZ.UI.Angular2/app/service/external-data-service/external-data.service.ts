import { Http, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ExternalDataService {
    private externalDataUrl = "http://localhost:59920/api/external/getData";
    private headers: Headers;

    constructor(private http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
    }

    public getExternalData(): Promise<string> {
        return this.http.get(this.externalDataUrl).toPromise()
            .then(resp => {
                console.log(resp.json());
                return resp.json()[0].data;
            }).catch(this.errorHandler);
    }

    public errorHandler(error: any) {
        console.error("Error message: ", error);
        return Promise.reject(error.message || error);
    }
}