import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AddIssue } from '../../../../Models/AddIssue';
import { UserService } from '../../../../Services/user.service';
import { IssueService } from '../../../../Services/issue.service';

@Component({
  selector: 'app-issue-modal',
  templateUrl: './issue-modal.component.html',
  styleUrl: './issue-modal.component.css'
})
export class IssueModalComponent implements OnInit{

  constructor(private fb:FormBuilder, private route:ActivatedRoute, private userservice:UserService, private issueService:IssueService){}
  IssueForm!:FormGroup;
  ngOnInit(): void {
    this.createIssueForm();
  }
  createIssueForm(){
    this.IssueForm = this.fb.group({
      IssueTitle: ['',[Validators.required, Validators.maxLength(50)]],
      IssueDescription: ['',[Validators.maxLength(100)]],
      Status: ['ToDo',[Validators.required]],
      Priority: ['Low',[Validators.required]],
      StartDate: [''],
      EndDate: [''],
      Assignee: ['']
    })
  }

  submitIssue(){
    if(this.IssueForm?.valid){
      console.log(this.IssueForm.value);
      const newIssue:AddIssue = {
        issueTitle : this.IssueForm.value.IssueTitle,
        issueDescription: this.IssueForm.value.IssueDescription,
        status: this.IssueForm.value.Status,
        priority: this.IssueForm.value.Priority,
        startDate: this.IssueForm.value.StartDate,
        endDate: this.IssueForm.value.EndDate ? this.IssueForm.value.EndDate : Date.now()+7,
        scrumUserId: this.IssueForm.value.Assignee || this.userservice.getIdFromToken(),
        projectId: this.route.snapshot.params['projectId']
      }
      this.issueService.createIssue(newIssue).subscribe({
        next:(res)=>{
          console.log(res);
          
        },
        error:(err)=>{
          console.log(err);
          
        },
        complete:()=>{

        }
      })
    }
  }

  // getter of issue form
  get IssueTitle(){
    return this.IssueForm.get('IssueTitle')
  }
  get IssueDescription(){
    return this.IssueForm.get('IssueDescription')
  }
  get Status(){
    return this.IssueForm.get('Status')
  }
  get Priority(){
    return this.IssueForm.get('Priority')
  }
  get StartDate(){
    return this.IssueForm.get('StartDate')
  }
  get EndDate(){
    return this.IssueForm.get('EndDate')
  }
  get Assignee(){
    return this.IssueForm.get('Assignee')
  }

}
