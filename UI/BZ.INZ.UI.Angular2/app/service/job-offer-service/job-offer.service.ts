import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { JobOffer } from '../../model/job-offer';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class JobOfferService {
    private jobOfferUrl = 'app/jobOffers';
    private headers: Headers;

    constructor(private http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
    }

    public getJobOffers(): Promise<JobOffer[]> {
        return this.http.get(this.jobOfferUrl).toPromise()
            .then(resp => resp.json().data as JobOffer[])
            .catch(this.errorHandler)
    }

    public getJobOffer(id: number): Promise<JobOffer> {
        return this.getJobOffers().then(jobs => jobs.find(x => x.id == id));
    }

    public createJobOffer(jobOffer: JobOffer): Promise<JobOffer> {
        return this.http
            .post(this.jobOfferUrl, JSON.stringify(jobOffer))
            .toPromise()
            .then(response => response.json().data)
            .catch(this.errorHandler);
    }

    public updateJobOffer(jobOffer: JobOffer): Promise<JobOffer> {
        const url = `${this.jobOfferUrl}/${jobOffer.id}`
        return this.http
            .put(url, JSON.stringify(jobOffer), this.headers)
            .toPromise()
            .then(() => jobOffer)
            .catch(this.errorHandler);
    }

    public deleteJobOffer(id: number): Promise<void> {
        const url = `${this.jobOfferUrl}/${id}`
        return this.http
            .delete(url, this.headers)
            .toPromise()
            .then(() => null)
            .catch(this.errorHandler);
    }

    public errorHandler(error: any) {
        console.error("Error message: ", error);
        return Promise.reject(error.message || error);
    }
}