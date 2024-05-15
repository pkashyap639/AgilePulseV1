import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../../../Services/user.service';
import { IssueService } from '../../../../Services/issue.service';

@Component({
  selector: 'app-issue-table',
  templateUrl: './issue-table.component.html',
  styleUrl: './issue-table.component.css'
})
export class IssueTableComponent implements OnInit{

  constructor(private route:ActivatedRoute, private userService:UserService, private issueService:IssueService){
  }
  allIssues:any;

  ngOnInit(): void {
    this.getAllIssues();
  }
  projectId = this.route.snapshot.params['projectId']
  getAllIssues(){
    let currentUser = this.userService.getIdFromToken()
    this.issueService.getIssues(currentUser,this.projectId).subscribe({
      next:(res)=>{
        console.log(res);
        this.allIssues = res
      },
      error:(err)=>{
        console.log(err);
        
      },
      complete:()=>{

      }
    })
  }
}
