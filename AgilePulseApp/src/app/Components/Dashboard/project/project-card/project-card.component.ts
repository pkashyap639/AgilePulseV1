import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProjectService } from '../../../../Services/project.service';
import { UserService } from '../../../../Services/user.service';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrl: './project-card.component.css'
})
export class ProjectCardComponent {

  @Input() public myProjectsData:any;
  @Output() public sendProjectdataToParent:any = new EventEmitter();
  constructor(private projectService:ProjectService, private userService:UserService){}

  deleteProject(LeadId:string, ProjectId:string){
    this.projectService.deleteProject(LeadId,ProjectId).subscribe({
      next:(res)=>{
        console.log(res);
        
      },
      error:(err)=>{
        console.log(err);
        
      },
      complete:()=>{
        console.log("Project Deleted");
        this.getAllProject();
      }
    }) 
  }

  getAllProject(){
    this.projectService.getProject(this.userService.getIdFromToken()).subscribe({
      next:(res)=>{
        this.sendProjectdataToParent.emit(res);
      }
    })
  }
}
