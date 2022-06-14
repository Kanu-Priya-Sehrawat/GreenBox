import { Component, OnInit } from '@angular/core';
import { PlasticService } from 'src/app/services/plastic.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-property-card',
    templateUrl: 'property-card.component.html',
    styleUrls: ['property-card.component.css']
}

)
export class PropertyCardComponent implements OnInit {
    weightOneDay: any;
    weightOneWeek: any;
    weightOneMonth: any;
    constructor(
        private route: ActivatedRoute,
        private plasticService: PlasticService,
        private alertify: AlertifyService,
        private router: Router) { }
    ngOnInit(): void {
        if(!localStorage.getItem('userName'))
        {
            this.alertify.error('You must logged in to track your plastic');
            this.router.navigate(['/user/login']);
        }
        this.plasticService.getTrackOneDay().subscribe( ( allData ) => {
            console.log( allData );
            this.weightOneDay=allData;
        });
        this.plasticService.getTrackOneWeek().subscribe( ( allData ) => {
            console.log( allData );
            this.weightOneWeek=allData;
        });
        this.plasticService.getTrackOneMonth().subscribe( ( allData ) => {
            console.log( allData );
            this.weightOneMonth=allData;
        } );
    }
}
