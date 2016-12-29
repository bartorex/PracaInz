import { Component, OnInit } from '@angular/core';
import { JobOffer } from '../../model/job-offer';
import { JobOfferService } from '../../service/job-offer-service/job-offer.service';
import { MockedJobOffers } from '../../mocks/mock-job-offer';
import { Router } from '@angular/router'

@Component({
    selector: 'job-offers-dashboard',
    templateUrl: '../../app/component/job-offer-dashboard/job-offer-dashboard.component.html',
    styleUrls: ['../../app/component/job-offer-dashboard/job-offer-dashboard.component.css']
})
export class JobOffersDashboard implements OnInit {
    public jobOffers: JobOffer[];

    constructor(
        private jobOfferService: JobOfferService,
        private router: Router
    ) { }

    getJobOffers(): void {
        this.jobOfferService
            .getJobOffers()
            .then(j => this.jobOffers = j);
    }

    getMockedJobOffers(): void {
        this.jobOffers = MockedJobOffers.slice(1, 5);
    }

    goToDetail(jobOffer: JobOffer): void {
        let link = ['/offerDetails', jobOffer.id];
        this.router.navigate(link);
    }

    ngOnInit(): void {
        this.getJobOffers();
    }
}