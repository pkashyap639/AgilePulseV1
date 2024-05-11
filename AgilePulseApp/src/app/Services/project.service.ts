import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddProject } from '../Models/AddProject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient) { }
  apiUrl = "https://localhost:7208/api/Project"


  addProject(project:AddProject):Observable<any>{
    return this.http.post(this.apiUrl, project);
  }

  getProject(id:string):Observable<any>{
    return this.http.get(`${this.apiUrl}/${id}`);
  }
}
