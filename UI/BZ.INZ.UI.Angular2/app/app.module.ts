import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HeroesComponent } from './heroes.component';
import { HeroService } from './hero.service';
import { HeroSearchComponent } from "./component/hero-search/hero-search.component";
import { routing } from './app.routing';
import { DashboardComponent } from './dashboard.component';
import { HttpModule } from '@angular/http';

// Imports for loading & configuring the in-memory web api
import { InMemoryWebApiModule } from 'angular2-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import './extensions/rxjs-extensions';

import { JobOffersComponent } from './component/job-offers/job-offers.component';
import { JobOffersDashboard } from './component/job-offer-dashboard/job-offer-dashboard.component';
import { JobOfferService } from './service/job-offer-service/job-offer.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        InMemoryWebApiModule.forRoot(InMemoryDataService),
    ],
    declarations: [
        AppComponent,
        HeroesComponent,
        DashboardComponent,
        HeroSearchComponent,
        JobOffersComponent,
        JobOffersDashboard
    ],
    providers: [
        HeroService,
        JobOfferService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}