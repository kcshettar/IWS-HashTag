import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService} from './auth.service'
// import { Http } from '@angular/http';

@Component({
  moduleId: module.id,
  selector: 'register',
  templateUrl: 'register.component.html',
  // templateUrl: './register',
  styles: [`
  .error {
      background-color: #fff0f0
  }
`]
// template: '<h1>Register</h1>'
})
export class RegisterComponent  { 
  form;

  constructor(private authentication: AuthService, private fb: FormBuilder) {
    this.form = fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', [Validators.required, emailValid()]],
      password: ['', Validators.required],
      REpassword: ['', Validators.required]
    }, {validator: matchingFields('password', 'REpassword')})
  }

  onsubmit() {
    console.log(this.form.errors);
    this.authentication.register(this.form.value);

    alert('User Registered Successfully');
    location.href = "http://localhost:50016/Home/Welcome";
  }

  isValid(control) {
    return this.form.controls[control].invalid && this.form.controls[control].touched
  }
}

function matchingFields(field1, field2) {
  return form => {
    if(form.controls[field1].value !== form.controls[field2].value)
      return { mismatchedFields: true }
  }
}

function emailValid() {
  return control => {
    var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      return regex.test(control.value) ? null : { invalidEmail: true }
  }
}


