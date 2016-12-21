import { Component } from '@angular/core'
import { OnInit} from '@angular/core'
import { HeroDetailComponent} from './hero-detail.component'
import { Hero } from './hero'
import { HeroService} from './hero.service'
import {Router} from '@angular/router'

@Component({
    selector: 'my-heroes',
    directives: [HeroDetailComponent],
    templateUrl: 'app/heroes.component.html',
    styleUrls: ['app/heroes.component.css']
})
export class HeroesComponent implements OnInit {
    public selectedHero: Hero;
    public heroes: Hero[];
    constructor(
        private heroService: HeroService,
        private router: Router) {
    }

    onSelect(hero: Hero) {
        this.selectedHero = hero;
    }

    getHeroes() {
        this.heroService.getHeroesSlowly().then(heroes => this.heroes = heroes);
    }

    ngOnInit() {
        this.getHeroes();
    }

    gotoDetails(): void {
        let link = ['/detail', this.selectedHero.id];
        this.router.navigate(link);
    }

    create(heroName: string): void {
        if (!heroName) { return; }
        this.heroService.createHero(heroName).then(hero => {
            this.heroes.push(hero);
            this.selectedHero = null;
        });
    }

    delete(hero: Hero): void {
        this.heroService.deleteHero(hero.id)
            .then(() => {
                this.heroes = this.heroes.filter(h => h !== hero);
                if (this.selectedHero === hero) {
                    this.selectedHero = null;
                }
            });
    }
}


