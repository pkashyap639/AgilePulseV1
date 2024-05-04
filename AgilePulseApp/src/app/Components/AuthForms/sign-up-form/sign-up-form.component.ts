import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrl: './sign-up-form.component.css'
})
export class SignUpFormComponent implements OnInit{

  public signUpForm!:FormGroup;
  constructor(private fb:FormBuilder){
    this.createSignUpForm();
  }

  ngOnInit(): void {
    
  }

  createSignUpForm(){
    this.signUpForm = this.fb.group({
      username: ['',[Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['',[Validators.required,Validators.email,Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]],
      password: ['',[Validators.required,Validators.minLength(8), Validators.maxLength(20)]]
    })
  }

  SubmitSignUpDetails(){
    if(this.signUpForm.valid){
      console.log(this.signUpForm.value)
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
