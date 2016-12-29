import {Component} from '@angular/core';
import {HeroesComponent} from './heroes.component'

@Component({
    selector:'my-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css']
})
export class AppComponent{
    title = 'My Job Offers';
}