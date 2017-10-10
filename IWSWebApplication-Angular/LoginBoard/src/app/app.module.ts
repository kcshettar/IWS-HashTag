import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Http } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
// import { MaterialModule } from '@angular/material';

// import { MessagesComponent } from './messages-component';
// import { WebService } from './web.service';
import { AppComponent }  from './app.component';
import { RegisterComponent } from './register.component';
import { RouterModule } from '@angular/router';
import { AuthService} from './auth.service';



const appRoutes = [
  {
    path: 'register',
    component: RegisterComponent
  }
    // },
  // { path: '',
  //   redirectTo: '/app.component',
  //   pathMatch: 'full'
  // }
];

@NgModule({
  imports:      [ BrowserModule, HttpModule, FormsModule, ReactiveFormsModule, RouterModule.forRoot(appRoutes, { enableTracing: true })],
  // declarations: [ AppComponent, MessagesComponent ],
  declarations: [ AppComponent, RegisterComponent ],
  bootstrap:    [ AppComponent ],
  // providers: [WebService]
  providers: [AuthService]
})
export class AppModule { }
