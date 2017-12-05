import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import {
    FormGroup,
    FormBuilder,
    Validators,
    FormControl
} from '@angular/forms';
import { FormService } from './../../service/form.service';

@Component({
    selector: 'formsubmit',
    templateUrl: './formsubmit.component.html',
    styles: ['.error { background-color: #fff0f0 } ']
})

export class FormsubmitComponent {
    form: FormGroup;

    constructor(private fb: FormBuilder, private formsubmit : FormService ) {
        this.form = fb.group({
            firstName: ['', [Validators.required, firstNameValid(), Validators.minLength(2), Validators.maxLength(15)]],
            lastName: ['', [Validators.required, firstNameValid(), Validators.minLength(2), Validators.maxLength(15)]],
            eMail: ['', [Validators.required, emailValid()]],
            phone: ['', [Validators.required, phoneValid()]],
            jobId: ['', [Validators.required, Validators.minLength(24), Validators.maxLength(24)]],
            linkedIn: ['', [Validators.required, linkedInValid()]]
        })
    }

    onSubmit() {
        console.log(this.form.valid);
        this.formsubmit.submit(this.form.value);
        this.form.reset();
    }

    isValid(control: string) {
        return this.form.controls[control].invalid && this.form.controls[control].touched
    }
}

function emailValid() {
    return (control: FormGroup) => {
        var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regex.test(control.value) ? null : { invalidEmail: true }
    }
}

function phoneValid() {
    return (control: FormGroup) => {
        var regex = /^\d{3}-\d{3}-\d{4}$/;
        return regex.test(control.value) ? null : { invalidPhone: true }
    }
}

function linkedInValid() {
    return (control: FormGroup) => {
        var regex = /^(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9]\.[^\s]{2,})/;
        return regex.test(control.value) ? null : { invalidLinkedIn: true }
    }
}

function NoWhitespaceValidator() {
    return (control: FormGroup) => {
        let isWhitespace = (control.value || '').trim().length === 0;
        let isValid = !isWhitespace;
        return isValid ? null : { 'whitespace': true }
    }
}

function firstNameValid() {
    return (control: FormGroup) => {
        var regex = /^([a-zA-Z]\s*)+/;
        return regex.test(control.value) ? null : { invalidFirstName: true }
    }
}