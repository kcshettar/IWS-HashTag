import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ApplyComponent } from './components/apply/apply.component';
import { FormsubmitComponent } from './components/formsubmit/formsubmit.component';

import { FormService } from './../app/service/form.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ApplyComponent,
        FormsubmitComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'apply', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'apply', component: ApplyComponent },
            { path: 'form-submit', component: FormsubmitComponent },
            { path: '**', redirectTo: 'apply' }
        ])
    ],
    providers: [FormService]
})
export class AppModuleShared {
}
