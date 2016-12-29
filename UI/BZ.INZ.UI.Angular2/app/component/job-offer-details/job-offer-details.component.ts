import { Component, Input, OnInit } from '@angular/core';
import { JobOffer } from '../../model/job-offer';
import { JobOfferService } from '../../service/job-offer-service/job-offer.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'job-offer-detail',
    templateUrl: '../../app/component/job-offer-details/job-offer-details.component.html',
    styleUrls: ['../../app/component/job-offer-details/job-offer-details.component.css']
})
export class JobOfferDetailComponent implements OnInit {
    @Input()
    public jobOffer: JobOffer;
    constructor(
        private jobOfferService: JobOfferService,
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = params['id'];
            console.log(id);
            this.jobOfferService.getJobOffer(id)
                .then(jobOffer => {
                    console.log(jobOffer);
                    this.jobOffer = jobOffer;
                });
        });
    }

    goBack(): void {
        window.history.back();
    }

    save(): void {
        this.jobOfferService.updateJobOffer(this.jobOffer);
    }
}