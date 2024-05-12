import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SignInFormComponent } from './Components/AuthForms/sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './Components/AuthForms/sign-up-form/sign-up-form.component';
import { DashboardComponent } from './Components/Dashboard/dashboard/dashboard.component';
import { authGuard } from './Gaurds/auth.guard';
import { noAuthGuard } from './Gaurds/no-auth.guard';
import { noAuthFormGuard } from './Gaurds/no-auth-form.guard';
import { ProjectComponent } from './Components/Dashboard/project/project.component';
import { IssueComponent } from './Components/Dashboard/issue/issue.component';
import { CycleComponent } from './Components/Dashboard/cycle/cycle.component';

const routes: Routes = [
  {path: '', component:SignUpFormComponent},
  {path: 'signin', component: SignInFormComponent},
  {path: 'signup', component: SignUpFormComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate:[authGuard],
    children:[
      {path:'', redirectTo:'project', pathMatch:'full'},
      {path:'project', component: ProjectComponent,canActivate:[authGuard]},
      {path:'issue/:projectId', component: IssueComponent,canActivate:[authGuard]},
      {path:'cycle', component: CycleComponent,canActivate:[authGuard]}
    ]
  },
  {path: '**', component:SignUpFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
