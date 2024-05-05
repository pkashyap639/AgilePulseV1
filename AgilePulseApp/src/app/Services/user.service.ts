import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateScrumuser } from '../Models/CreateScrumUser';
import { Observable } from 'rxjs';
import { loginScrumUser } from '../Models/LoginScrumUser';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient, private route:Router) { }
  apiUrl = "https://localhost:7208/api/ScrumUser/"
  // Create Scrum User
  createScrumUser(scrumUser:CreateScrumuser):Observable<any>{
    return this.http.post<any>(this.apiUrl,scrumUser);
  }

  //Login Scrum User
  loginScrumUser(scrumUser:loginScrumUser):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}login/`,scrumUser);
  }

  // set session storage
  setTokenToSession(token:string){
    sessionStorage.setItem("Token",token)
  }

  //SignOut
  signout(){
    sessionStorage.clear();
    this.route.navigate(['signin'])
  }
  // check if authenticated
  checkIfAuth(){
    if(sessionStorage.getItem('Token')){
      return true
    }
    return false
  }
}
