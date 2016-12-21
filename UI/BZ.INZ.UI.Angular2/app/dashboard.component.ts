import {Component, OnInit} from '@angular/core';
import {HeroService} from './hero.service';
import {Hero} from './hero';
import {Router} from '@angular/router';

@Component({
  selector: 'my-dashboard',
  templateUrl: 'app/dashboard.component.html',
  styleUrls: ['app/dashboard.component.css']
})
export class DashboardComponent {
  public heroes: Hero[];
  constructor(
    private heroService: HeroService,
    private router: Router) {
  }

  getHeroes() {
    this.heroService.
      getHeroes().then(heroes => this.heroes = heroes.slice(1, 5));
  }

  ngOnInit() {
    this.getHeroes();
  }

  goToDetail(hero: Hero) {
    let link = ['/detail', hero.id];
    this.router.navigate(link);
  }
}