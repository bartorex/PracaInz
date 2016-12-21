import {Injectable} from '@angular/core';
import {Hero} from './hero';
import {HEROES} from './mock-heroes';
import {Http, Headers} from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class HeroService {

    private heroesUrl = 'app/heroes';
    private headers: Headers;

    constructor(private http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
    }

    public getHeroes(): Promise<Hero[]> {
        return this.http.get(this.heroesUrl).toPromise()
            .then(response => response.json().data as Hero[])
            .catch(this.handleError);
    }

    public getHeroesSlowly(): Promise<Hero[]> {
        return new Promise<Hero[]>(resolve =>
            setTimeout(() => resolve(this.getHeroes()), 2000) // 2 seconds
        );
    }

    public getHero(id: number): Promise<Hero> {
        return this.getHeroes().then(heroes => heroes.find(x => x.id === id));
    }

    public updateHero(hero: Hero): Promise<Hero> {
        const url = `${this.heroesUrl}/${hero.id}`;
        return this.http
            .put(url, JSON.stringify(hero), this.headers)
            .toPromise()
            .then(() => hero)
            .catch(this.handleError);
    }

    public createHero(heroName: string): Promise<Hero> {
        return this.http
            .post(this.heroesUrl, JSON.stringify({ name: heroName }), this.headers)
            .toPromise()
            .then(response => response.json().data)
            .catch(this.handleError);
    }

    public deleteHero(id: number): Promise<void> {
        const url = `${this.heroesUrl}/${id}`;
        return this.http
            .delete(url,this.headers)
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error("An error occurred", error);
        return Promise.reject(error.message || error);
    }
}

