import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'apply',
    templateUrl: './apply.component.html',
    styleUrls: ['./ApplyComponentStyleSheet.css']
})
export class ApplyComponent {
    public jobroles: JobApply[];
    form: FormGroup;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private fb:FormBuilder) {
        http.get(baseUrl + 'api/JobApply/GetAllJobs').subscribe(result => {
            this.jobroles = result.json() as JobApply[];
        }, error => console.error(error));

        this.form = fb.group({
            jobtest: ''
        })
    }

    onSubmit() {
        location.replace("/form-submit");
    }
}

interface JobApply {
    jobid: string;
    jobname: string;
    jobskills: string; 
    jobcompany: string;
    joblocation: string;
    jobemail: string;
}