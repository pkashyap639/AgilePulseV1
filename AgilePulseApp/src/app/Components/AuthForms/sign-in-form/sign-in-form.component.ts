import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrl: './sign-in-form.component.css'
})
export class SignInFormComponent implements OnInit{
  public signInForm!:FormGroup;

  constructor(private fb:FormBuilder){
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
    if(this.signInForm.valid){
      console.log(this.signInForm.value)
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
