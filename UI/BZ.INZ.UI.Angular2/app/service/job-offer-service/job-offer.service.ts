import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { JobOffer } from '../../model/job-offer';
import { CreateJobOfferCommand } from '../../model/command/create-job-offer-command';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class JobOfferService {
    // private jobOfferUrl = 'app/jobOffers';
    private jobOfferUrl = "http://localhost:59920/api/jobOffersQuery";
    private createJobOfferCommandUrl = "http://localhost:59920/api/command/CreateJobOffer";
    private headers: Headers;

    constructor(private http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
    }

    public getJobOffers(): Promise<JobOffer[]> {
        var url = `${this.jobOfferUrl}/getOffers`;
        return this.http.get(url).toPromise()
            .then(resp => {
                return resp.json() as JobOffer[]
            })
            .catch(this.errorHandler)
    }

    public getJobOffer(id: string): Promise<JobOffer> {
        console.log(id);
        return this.getJobOffers().then(jobs => jobs.find(x => x.id === id));
    }

    public createJobOfferFromName(offerName: string): Promise<JobOffer> {
        var jobOffer: JobOffer = { id: "00000000-0000-0000-0000-000000000000", 
            content: null, 
            dateRequested: new Date().toDateString(), 
            employerId: "00000000-0000-0000-0000-000000000000", 
            name: offerName 
        };
        return this.createJobOffer(jobOffer);
    }

    public createJobOffer(jobOffer: JobOffer): Promise<JobOffer> {
        var command: CreateJobOfferCommand = { jobOffer: jobOffer };
        let options = new RequestOptions({ headers: this.headers });

        return this.http
            .post(this.createJobOfferCommandUrl, JSON.stringify(command), options)
            .toPromise()
            .then(response => response.json().value)
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