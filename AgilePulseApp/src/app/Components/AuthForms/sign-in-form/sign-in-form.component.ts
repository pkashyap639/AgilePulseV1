import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { CreateScrumuser } from '../../../Models/CreateScrumUser';
import { UserService } from '../../../Services/user.service';
import { loginScrumUser } from '../../../Models/LoginScrumUser';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrl: './sign-in-form.component.css'
})
export class SignInFormComponent implements OnInit{
  public signInForm!:FormGroup;
  public showLoadingSpinner:boolean = false;
  public showSuccessToast:boolean = false;
  public showErrorToast:boolean = false;

  constructor(private fb:FormBuilder, private userService:UserService, private route:Router){
    this.createSignInForm();
  }
  ngOnInit(): void {
    
  }

  createSignInForm(){
    this.signInForm = this.fb.group({
      email: ['',[Validators.required,Validators.email,Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]],
      password: ['',[Validators.required,Validators.minLength(8), Validators.maxLength(20)]]
    })
  }

  SubmitSignInDetails(){
    this.showLoadingSpinner = true
    if(this.signInForm.valid){
      let scrumUser:loginScrumUser = {
        Email : this.signInForm.value.email,
        Password: this.signInForm.value.password
      }
      this.userService.loginScrumUser(scrumUser).subscribe({
        next:(res)=>{
          console.log(res);
          
        },
        error:(err)=>{
          console.error(err);
          this.showLoadingSpinner = false;
          this.showErrorToast = true;
          setTimeout(() => {
            this.showErrorToast = false;
          }, 3000);
        },
        complete:()=>{
          console.log("Completed");
          this.showLoadingSpinner = false;
          this.showSuccessToast = true;
          setTimeout(() => {
            this.showSuccessToast = false;
          }, 3000);
          this.route.navigate(['dashboard'])
        }
      });
    }
    else{
      console.log("Invalid Form")
    }
  }

  checkFormValidity(){
    if(this.signInForm.invalid)return true
    return false
  }
  // getters for controlnames

  get email(){
    return this.signInForm.get('email')
  }
  get password(){
    return this.signInForm.get('password')
  }
}
