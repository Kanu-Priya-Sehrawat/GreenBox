import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import {FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { TabsetComponent } from 'ngx-bootstrap/tabs/public_api';
import { AlertifyService } from 'src/app/services/alertify.service';
import { DatePipe } from '@angular/common';
import { PlasticService } from 'src/app/services/plastic.service';


@Component({
    selector: 'app-add-property',
    templateUrl: './add-property.component.html',
    styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit {
    // @ViewChild('Form') addPropertyForm: NgForm;
    @ViewChild('formTabs') formTabs: TabsetComponent;
    addPropertyForm = new FormGroup({
        name: new FormControl(' '),
        quantity: new FormControl(' '),
        plasticTypeId: new FormControl(' '),
        wt: new FormControl(' '),
        size: new FormControl(' '),
        description: new FormControl(' ')
    });



    constructor(
        private datePipe: DatePipe,
        private fb: FormBuilder,
        private router: Router,
        private plasticService: PlasticService,
        private alertify: AlertifyService) { }

    ngOnInit() {
        if(!localStorage.getItem('userName'))
        {
            this.alertify.error('You must logged in to add your plastic');
            this.router.navigate(['/user/login']);
        }
    }

    onSubmit() {
        console.log(this.addPropertyForm);
        this.plasticService.savePlasticData(this.addPropertyForm.value).subscribe(
            () => {
                this.alertify.success('Congrats, your property listed successfully on our website');
                console.log(this.addPropertyForm);

            }
        );
    }


}
