import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public jobroles: Job[];
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Job/GetAllJobs').subscribe(result => {
            this.jobroles = result.json() as Job[];
        }, error => console.error(error));


        //this.form = fb.group({
        //    firstName: ['']
        //})
    }


    //    this.form = fb.group({
    //        firstName: ['', Validators.required],
    //        lastName: ['', Validators.required],
    //        eMail: ['', [Validators.required, emailValid()]],
    //        userPassword: ['', Validators.required],
    //        reuserPassword: ['', Validators.required]
    //    }, { validator: matchingFields('userPassword', 'reuserPassword') })
    //}
}

interface Job {
    companyname: string;
    jobrole: string;
    joblocation: string;
    jobdate: string;
}