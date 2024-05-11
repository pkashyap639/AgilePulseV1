import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateScrumuser } from '../Models/CreateScrumUser';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { loginScrumUser } from '../Models/LoginScrumUser';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userPayload:any;
  constructor(private http:HttpClient, private route:Router, private jwt:JwtHelperService) { 
    this.userPayload = this.decodeToken();
  }
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

// get token
  getToken(){
    return sessionStorage.getItem('Token')
  }

  // decode token
  decodeToken(){
    return this.jwt.decodeToken(this.getToken()!);
  }

  getNameFromToken(){
    if(this.userPayload) return this.userPayload.Name;
  }

  getIdFromToken(){
    if(this.userPayload) return this.userPayload.ScrumUserId;

  }

}
