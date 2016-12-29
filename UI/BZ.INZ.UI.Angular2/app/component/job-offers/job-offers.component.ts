import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { JobOffer } from '../../model/job-offer';
import { JobOfferService } from '../../service/job-offer-service/job-offer.service';
import { MockedJobOffers } from '../../mocks/mock-job-offer';
import { Router } from '@angular/router'

@Component({
    selector: 'my-job-offers',
    templateUrl: '../../app/component/job-offers/job-offers.component.html',
    styleUrls: ['../../app/component/job-offers/job-offers.component.css']
})
export class JobOffersComponent implements OnInit {
    public selectedJobOffer: JobOffer;
    public jobOffers: JobOffer[];

    constructor(
        private jobOfferService: JobOfferService,
        private router: Router
    ) { }

    getJobsOffers(): void {
        this.jobOfferService.getJobOffers().then(jobOffers => this.jobOffers = jobOffers);
    }

    getMockedJobOffers(): void {
        this.jobOffers = MockedJobOffers;
    }

    ngOnInit(): void {
        this.getJobsOffers();
    }

    onSelect(jobOffer: JobOffer): void {
        this.selectedJobOffer = jobOffer;
    }

    // create(jobOffer: JobOffer): void {
    //     if (!jobOffer) { return; }
    //     this.jobOfferService.createJobOffer(jobOffer)
    //         .then(jobOffer => {
    //             this.jobOffers.push(jobOffer);
    //             this.selectedJobOffer = null;
    //         });
    // }

    create(offerName: string): void {
        if (!offerName) { return; }
        this.jobOfferService.createJobOfferFromName(offerName)
            .then(jobOffer => {
                this.jobOffers.push(jobOffer);
                this.selectedJobOffer = null;
            });
    }

    delete(jobOffer: JobOffer): void {
        this.jobOfferService.deleteJobOffer(jobOffer.id)
            .then(() => {
                this.jobOffers = this.jobOffers.filter(jb => jb !== jobOffer);
                if (this.selectedJobOffer === jobOffer) {
                    this.selectedJobOffer = null;
                }
            });
    }

    gotoDetails(): void {
        let link = ['/offerDetails', this.selectedJobOffer.id];
        this.router.navigate(link);
    }
}