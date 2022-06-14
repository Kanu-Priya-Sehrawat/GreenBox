import { Component, OnInit } from '@angular/core';
import { PlasticService } from 'src/app/services/plastic.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-property-list',
    templateUrl: './property-list.component.html',
    styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

    plasticData: any=[];

    constructor(
        private route: ActivatedRoute,
        private plasticService: PlasticService,
        private alertify: AlertifyService,
        private router: Router) { }

    ngOnInit(): void {
        if(!localStorage.getItem('userName'))
        {
            this.alertify.error('You must logged in to get your plastic bag');
            this.router.navigate(['/user/login']);
        }

        this.plasticService.getAllPlastic().subscribe( ( allData ) => {
            console.log( allData );
            this.plasticData=allData;
        } );
    }


}
