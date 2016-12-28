import { Routes, RouterModule } from '@angular/router'
import { HeroesComponent } from './heroes.component'
import { DashboardComponent } from './dashboard.component'
import { HeroDetailComponent } from './hero-detail.component'
import { JobOffersComponent } from './component/job-offers/job-offers.component'
import { JobOffersDashboard } from './component/job-offer-dashboard/job-offer-dashboard.component'

const appRoutes: Routes = [{
    path: 'heroes',
    component: HeroesComponent
}, {
    path: 'dashboard',
    component: DashboardComponent
}, {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
}, {
    path: 'detail/:id',
    component: HeroDetailComponent
}, {
    path: 'offers',
    component: JobOffersComponent
}, {
    path: 'offersdashboard',
    component: JobOffersDashboard
}];

export const routing = RouterModule.forRoot(appRoutes);