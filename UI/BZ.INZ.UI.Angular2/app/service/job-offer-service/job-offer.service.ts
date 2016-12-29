import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { JobOffer } from '../../model/job-offer';
import { CreateJobOfferCommand } from '../../model/command/create-job-offer-command';
import { DeleteJobOfferCommand } from '../../model/command/delete-job-offer-command';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class JobOfferService {
    // private jobOfferUrl = 'app/jobOffers';
    private jobOfferUrl = "http://localhost:59920/api/jobOffersQuery";
    private createJobOfferCommandUrl = "http://localhost:59920/api/command/CreateJobOffer";
    private updateJobOfferCommandUrl = "http://localhost:59920/api/command/UpdateJobOffer";
    private deleteJobOfferCommandUrl = "http://localhost:59920/api/command/DeleteJobOffer";
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
        var jobOffer: JobOffer = {
            id: "00000000-0000-0000-0000-000000000000",
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
        var command: CreateJobOfferCommand = { jobOffer: jobOffer };
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .post(this.updateJobOfferCommandUrl, JSON.stringify(command), options)
            .toPromise()
            .then(response => response.json().value)
            .catch(this.errorHandler);
    }

    public deleteJobOffer(id: string): Promise<void> {
        var command: DeleteJobOfferCommand = { id: id };
        let options = new RequestOptions({ headers: this.headers });
        return this.http
            .post(this.deleteJobOfferCommandUrl, JSON.stringify(command) ,options)
            .toPromise()
            .then(() => null)
            .catch(this.errorHandler);
    }

    public errorHandler(error: any) {
        console.error("Error message: ", error);
        return Promise.reject(error.message || error);
    }
}