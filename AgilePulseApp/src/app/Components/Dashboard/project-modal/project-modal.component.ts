import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-project-modal',
  templateUrl: './project-modal.component.html',
  styleUrl: './project-modal.component.css'
})
export class ProjectModalComponent implements OnInit{

  addProjectForm!:FormGroup;
  constructor(private fb:FormBuilder) {
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
      console.log(this.addProjectForm.value);
      
    }
  }

  // getter and setter
  get projectName(){
    return this.addProjectForm.get('projectName')
  }
  get projectDescription(){
    return this.addProjectForm.get('projectDescription')
  }}
