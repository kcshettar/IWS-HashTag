import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'apply',
    templateUrl: './apply.component.html'
})
export class ApplyComponent {
    public jobroles: JobApply[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/JobApply/GetAllJobs').subscribe(result => {
            this.jobroles = result.json() as JobApply[];
        }, error => console.error(error));
    }
}

interface JobApply {
    jobname: string;    //location: string;
    jobskills: string; 
    jobcompany: string;
    joblocation: string;
    jobemail: string;
}