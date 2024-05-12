import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-issue-modal',
  templateUrl: './issue-modal.component.html',
  styleUrl: './issue-modal.component.css'
})
export class IssueModalComponent implements OnInit{

  constructor(private fb:FormBuilder){}
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
      StartDate: [formatDate(new Date(), 'yyyy-MM-dd', 'en'), [Validators.required]],
      EndDate: [''],
      Assignee: ['']
    })
  }

  submitIssue(){
    if(this.IssueForm?.valid){
      console.log(this.IssueForm.value);
      
    }
  }
}
