import { Component } from '@angular/core';
// import { MessagesComponent } from './messages-component';

@Component({
  selector: 'my-app',
  // template: `<h1>Hello {{name}}</h1> <messages></messages>`,
  template: `<router-outlet></router-outlet>`,
})
export class AppComponent  { name = 'World'; }