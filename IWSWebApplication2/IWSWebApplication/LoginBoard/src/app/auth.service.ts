import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {

    BASE_URL = 'http://localhost:50016/auth';
    NAME_KEY = 'firstname';
    TOKEN_KEY = 'token';

    constructor(private http: Http, private router: Router) {}

    get firstname() {
        return localStorage.getItem(this.NAME_KEY);
    }

    get isAuthenticated() {
        return !!localStorage.getItem(this.TOKEN_KEY);
    }

    register(user) {
        delete user.REpassword;
        this.http.post(this.BASE_URL + '/register', user).subscribe(res => {

            var authResponse = res.json();
            if(!authResponse.token)
                return;

            localStorage.setItem(this.TOKEN_KEY, authResponse.token)
            localStorage.setItem(this.NAME_KEY, authResponse.firstName)
            this.router.navigate([location.href = "http://localhost:50016/"]);
        });
    }

    //Logout logic should be in component file not in .html
    // logout() {
    //     localStorage.removeItem(this.NAME_KEY);
    //     localStorage.removeItem(this.TOKEN_KEY);
    // }
}