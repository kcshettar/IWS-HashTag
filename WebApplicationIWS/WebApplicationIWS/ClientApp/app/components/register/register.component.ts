import { Component, Inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
//import { MdInput, MdButton } from '@angular/material';

import { AuthService } from './../services/auth.service';

@Component({
    //moduleId: module.id,
    selector: 'register',
    templateUrl: './register.component.html',
    //styleUrls: ['./register.component.css'],
    styles: ['.error{ background-color: #fff0f0 }']
})

export class RegisterComponent {
    form: FormGroup;

    constructor(private fb: FormBuilder, private auth: AuthService) {
        this.form = fb.group({
            firstName: [ '', Validators.required ],
            lastName: ['', Validators.required],
            eMail: ['', [Validators.required, emailValid()]],
            userPassword: ['', Validators.required],
            reuserPassword: ['', Validators.required]
        }, { validator: matchingFields('userPassword', 'reuserPassword')})
    }
    
    onSubmit() {
        console.log(this.form.errors);
        this.auth.register(this.form.value);
    }
    
    isValid(control: string) {
        return this.form.controls[control].invalid && this.form.controls[control].touched
    }
}


function matchingFields(userPassword: string, reuserPassword: string)
{
    return (form: FormGroup) => {
        if (form.controls[userPassword].value !== form.controls[reuserPassword].value)
        {
            return {mismatchFields: true}
        }
    }
}

function emailValid() {
    return (control: FormGroup) => {
        var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regex.test(control.value) ? null : {invalidEmail: true}
    }
}