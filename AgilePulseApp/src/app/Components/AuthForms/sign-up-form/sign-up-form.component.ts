import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { CreateScrumuser } from '../../../Models/CreateScrumUser';
import { UserService } from '../../../Services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrl: './sign-up-form.component.css'
})
export class SignUpFormComponent implements OnInit{

  public signUpForm!:FormGroup;
  public showLoadingSpinner:boolean = false;
  public showSuccessToast:boolean = false;
  public showErrorToast:boolean = false;
  constructor(private fb:FormBuilder, private userService:UserService, private route:Router){
    this.createSignUpForm();
  }

  ngOnInit(): void {
    if(this.userService.checkIfAuth()) this.route.navigate(['dashboard'])

  }

  createSignUpForm(){
    this.signUpForm = this.fb.group({
      username: ['',[Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['',[Validators.required,Validators.email,Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]],
      password: ['',[Validators.required,Validators.minLength(8), Validators.maxLength(20)]]
    })
  }

  SubmitSignUpDetails(){
    this.showLoadingSpinner = true;
    if(this.signUpForm.valid){
      let scrumUser:CreateScrumuser = {
        ScrumUsername : this.signUpForm.value.username,
        Email : this.signUpForm.value.email,
        Password: this.signUpForm.value.password
      }
     this.userService.createScrumUser(scrumUser).subscribe({
      next:(data)=>{
        console.log(data);
      },
      error:(err)=>{
        console.error(err)
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
      }
     }); 
    }
    else{
      console.log("Invalid Form")
    }
  }

  checkFormValidity(){
    if(this.signUpForm.invalid)return true
    return false
  }
  // getters for controlnames
  get username(){
    return this.signUpForm.get('username')
  }
  get email(){
    return this.signUpForm.get('email')
  }
  get password(){
    return this.signUpForm.get('password')
  }
}
