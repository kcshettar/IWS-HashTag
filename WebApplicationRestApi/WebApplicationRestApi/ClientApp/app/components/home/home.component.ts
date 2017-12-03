import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

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
    }
}

interface Job {
    name: string;
    location: string;
}