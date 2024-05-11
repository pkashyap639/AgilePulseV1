import { Component, OnInit } from '@angular/core';
import { AddProject } from '../../../Models/AddProject';
import { ProjectService } from '../../../Services/project.service';
import { UserService } from '../../../Services/user.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrl: './project.component.css'
})
export class ProjectComponent implements OnInit{

  constructor(private projectService:ProjectService, private userService:UserService){}
  scrumUserId:string = ''
  projectsData:any;
  ngOnInit(): void {
    this.scrumUserId = this.userService.getIdFromToken();
    this.getAllProjects()
  }

  getAllProjects(){
    this.projectService.getProject(this.scrumUserId).subscribe({
      next:(res)=>{
        this.projectsData = res
        console.log(this.projectsData);

      },
      error:(err)=>{
        console.log(err);
        
      },
      complete:()=>{
        console.log("Fetched All Projects");
        
      }
    })
  }
}
