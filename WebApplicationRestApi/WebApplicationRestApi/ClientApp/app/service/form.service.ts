import { Injectable } from '@angular/core';
import { Http } from '@angular/http';


@Injectable()
export class FormService {
    BASE_URL = 'http://localhost:59253/userdata'

    constructor(private http: Http) { }

    submit(user: any) {
        this.http.post(this.BASE_URL + '/form-submit', user).subscribe();
    }
}