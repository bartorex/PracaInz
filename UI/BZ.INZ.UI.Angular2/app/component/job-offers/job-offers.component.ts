import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { JobOffer } from '../../model/job-offer';
import { JobOfferService } from '../../service/job-offer-service/job-offer.service';
import { MockedJobOffers } from '../../mocks/mock-job-offer';

@Component({
    selector: 'my-job-offers',
    templateUrl: '../../app/component/job-offers/job-offers.component.html'
})
export class JobOffersComponent implements OnInit {
    public selectedJobOffer: JobOffer;
    public jobOffers: JobOffer[];

    constructor(
        private jobOfferService: JobOfferService
    ) { }

    getJobsOffers(): void {
        this.jobOfferService.getJobOffers().then(jobOffers => this.jobOffers = jobOffers);
    }

    getMockedJobOffers(): void {
        this.jobOffers = MockedJobOffers;
    }

    ngOnInit(): void {
        //  this.getJobsOffers();
        this.getMockedJobOffers();
    }

    onSelect(jobOffer: JobOffer): void {
        this.selectedJobOffer = jobOffer;
    }

    create(jobOffer: JobOffer): void {

    }
}