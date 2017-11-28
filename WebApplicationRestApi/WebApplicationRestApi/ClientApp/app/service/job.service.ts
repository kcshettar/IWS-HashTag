import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

//export interface Job {
//    name: string;
//}

@Injectable()
export class JobService {
    constructor(private http: Http, private router: Router) { }


    //register(job) {
    //    //delete user.reuserPassword;
    //    this.http.post(this.BASE_URL + '/register', job).subscribe(
    //        res => {
    //            var authResponse = res.json();

    //            if (!authResponse.token)
    //                return;
    //            localStorage.setItem('token', authResponse.token)
    //            localStorage.setItem('name', authResponse.firstName)

    //            this.router.navigate(['/']);
    //        });
    //}

    //getAllJobs(): Observable<Job[]> {
    //    return this.http.get<Job[]>('http://localhost:59253/api/Job/');
    //}

    //getJob(name: string): Observable<Job> {
    //    return this.http.get<Job>('http://localhost:59253/api/Job/' + name);
    //}

    //insertJob(job: Job): Observable<Job> {
    //    return this.http.post<Job>('http://localhost:59253/api/Job/', job);
    //}

    //updateJob(job: Job): Observable<void> {
    //    return this.http.put<void>('http://localhost:59253/api/Job' + job.name, job);
    //}

    //deleteCat(name: string) {
    //    return this.http.delete('http://localhost:59253/api/Job' + name);
    //}
}