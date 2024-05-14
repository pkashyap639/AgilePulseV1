import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddIssue } from '../Models/AddIssue';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  constructor(private http:HttpClient) { }

  apiUrl = "https://localhost:7208/api/Issue"

  createIssue(issue:AddIssue):Observable<any>{
    return this.http.post(this.apiUrl,issue);
  }

  getIssues(scrumUserId:string, projectId:string){
    return this.http.get(`${this.apiUrl}/${scrumUserId}/${projectId}`);
  }
}
