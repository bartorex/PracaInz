import { InMemoryDbService } from 'angular2-in-memory-web-api';

export class MemoryJobOfferDataService implements InMemoryDbService {
    createDb() {
        let jobOffers = [
            { id: 1, name: 'Programista Java' },
            { id: 2, name: 'Starszy Architekt' },
            { id: 3, name: 'Product Owner' },
            { id: 4, name: 'Javascript dev' },
        ];

        return { jobOffers }
    }
}