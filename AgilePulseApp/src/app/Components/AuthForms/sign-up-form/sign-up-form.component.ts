import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators, EmailValidator } from '@angular/forms';
import { CreateScrumuser } from '../../../Models/CreateScrumUser';
import { UserService } from '../../../Services/user.service';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrl: './sign-up-form.component.css'
})
export class SignUpFormComponent implements OnInit{

  public signUpForm!:FormGroup;
  constructor(private fb:FormBuilder, private userService:UserService){
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
      },
      complete:()=>{
        console.log("Completed");
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
