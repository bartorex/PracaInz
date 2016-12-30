import { Component, Input, OnInit } from '@angular/core';
import { ExternalDataService } from '../../service/external-data-service/external-data.service';

@Component({
    selector: 'external-data',
    templateUrl: '../../app/component/external-data/external-data.component.html'
})
export class ExternalDataComponent implements OnInit {
    public externalData: string;
    constructor(private externalService: ExternalDataService) {

    }

    getExternalData(): void {
        this.externalService.getExternalData().then(data => {
            console.log(data);
            this.externalData = data;
        });
    }

    ngOnInit(): void {
        this.getExternalData();
    }
}