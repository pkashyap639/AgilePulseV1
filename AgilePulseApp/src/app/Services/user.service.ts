import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateScrumuser } from '../Models/CreateScrumUser';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }
  apiUrl = "https://localhost:7208/api/ScrumUser/"
  // Create Scrum User
  createScrumUser(scrumUser:CreateScrumuser):Observable<any>{
    return this.http.post<any>(this.apiUrl,scrumUser);
  }
}
