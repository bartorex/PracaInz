import {Component, Input, OnInit } from '@angular/core';
import {JobOffer} from '../../model/job-offer';
import {JobOfferService} from '../../service/job-offer-service/job-offer.service';
import {ActivatedRoute, Params} from '@angular/router';
// import {}

@Component({
    selector: 'my-hero-detail',
    templateUrl: 'app/hero-detail.component.html',
    styleUrls: ['app/hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {
    @Input()
    jobOffer: JobOffer;

    constructor(
        private jobOfferService: JobOfferService,
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = +params['id'];
            // this.jobOffer.getHero(id)
            //     .then(hero => this.hero = hero);
        });
    }

    goBack(): void {
        window.history.back();
    }

    save(): void {
        this.jobOfferService.updateJobOffer(this.jobOffer);
    }
}