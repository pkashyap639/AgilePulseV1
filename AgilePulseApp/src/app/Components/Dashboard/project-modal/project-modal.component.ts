import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../Services/user.service';
import { AddProject } from '../../../Models/AddProject';
import { ProjectService } from '../../../Services/project.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project-modal',
  templateUrl: './project-modal.component.html',
  styleUrl: './project-modal.component.css'
})
export class ProjectModalComponent implements OnInit{

  addProjectForm!:FormGroup;
  @Output() public addProjectData = new EventEmitter();
  showModal = true;
  constructor(private fb:FormBuilder, private userService:UserService, private projectService:ProjectService, private route:Router) {
    this.createAddProjectForm();
    
  }
  ngOnInit(): void {
    
  }

  createAddProjectForm(){
    this.addProjectForm = this.fb.group({
      projectName : ['',[Validators.required]],
      projectDescription : ['',[]],
    })
  }

  addProject(){
    if(this.addProjectForm.valid){
      const LeadId = this.userService.getIdFromToken()
      let addProject:AddProject = {
        Title: this.addProjectForm.value.projectName,
        Description: this.addProjectForm.value.projectDescription,
        LeadId: LeadId
      }
      this.addProjectData.emit(addProject);
      console.log(addProject);
      this.projectService.addProject(addProject).subscribe({
        next:(res)=>{
          console.log(res);
          this.route.navigate(['dashboard'])
        },
        error:(err)=>{
          console.log(err);
          
        },
        complete:()=>{
          this.showModal = false
        }
      });
      
    }
  }

  // getter and setter
  get projectName(){
    return this.addProjectForm.get('projectName')
  }
  get projectDescription(){
    return this.addProjectForm.get('projectDescription')
  }}
