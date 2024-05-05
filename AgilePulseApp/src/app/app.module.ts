import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInFormComponent } from './Components/AuthForms/sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './Components/AuthForms/sign-up-form/sign-up-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './Components/Dashboard/dashboard/dashboard.component';


@NgModule({
  declarations: [
    AppComponent,
    SignInFormComponent,
    SignUpFormComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
