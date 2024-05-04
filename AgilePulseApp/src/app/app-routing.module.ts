import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInFormComponent } from './Components/AuthForms/sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './Components/AuthForms/sign-up-form/sign-up-form.component';

const routes: Routes = [
  {path: '', component:SignUpFormComponent},
  {path: 'signin', component: SignInFormComponent},
  {path: 'signup', component: SignUpFormComponent},
  {path: '**', component:SignUpFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
