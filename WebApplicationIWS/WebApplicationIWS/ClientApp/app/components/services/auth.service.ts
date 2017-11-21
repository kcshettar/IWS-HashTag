import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

//import { OnInit, PLATFORM_ID, Inject } from '@angular/core';
//import { isPlatformServer, isPlatformBrowser } from '@angular/common';

@Injectable()
export class AuthService {

    BASE_URL = 'http://localhost:54446/api/auth';
    constructor(private http: Http, private router: Router) { }
    //NAME_KEY = 'name';
    LOCAL_STORAGE = localStorage.getItem(name);

    register(user) {
        delete user.reuserPassword;
        this.http.post(this.BASE_URL + '/register', user).subscribe(
            res => {

                var authResponse = res.json();

                if (!authResponse.token)
                    return;
                localStorage.setItem('token', authResponse.token)
                localStorage.setItem('name', authResponse.firstName)

                this.router.navigate(['/']);
            });
    }    

    //get name() {
    //    return this.LOCAL_STORAGE;
    //}

    //get isAuthenticated() {
    //    return localStorage.getItem('name');
    //}

    //logout() {
    //    localStorage.removeItem('name');
    //    localStorage.removeItem('token');
    //}
}