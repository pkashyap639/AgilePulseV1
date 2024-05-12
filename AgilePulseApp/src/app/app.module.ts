import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInFormComponent } from './Components/AuthForms/sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './Components/AuthForms/sign-up-form/sign-up-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './Components/Dashboard/dashboard/dashboard.component';
import { ProjectComponent } from './Components/Dashboard/project/project.component';
import { IssueComponent } from './Components/Dashboard/issue/issue.component';
import { CycleComponent } from './Components/Dashboard/cycle/cycle.component';
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtModule } from "@auth0/angular-jwt";
import { ProjectModalComponent } from './Components/Dashboard/project-modal/project-modal.component';
import { ProjectCardComponent } from './Components/Dashboard/project/project-card/project-card.component';
import { IssueModalComponent } from './Components/Dashboard/issue/issue-modal/issue-modal.component';

export function tokenGetter() {
  return sessionStorage.getItem("Token");
}

@NgModule({
  declarations: [
    AppComponent,
    SignInFormComponent,
    SignUpFormComponent,
    DashboardComponent,
    ProjectComponent,
    IssueComponent,
    CycleComponent,
    ProjectModalComponent,
    ProjectCardComponent,
    IssueModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["https://localhost:7208/"],
        disallowedRoutes: [],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
