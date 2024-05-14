import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../../Services/user.service';
import { IssueService } from '../../../Services/issue.service';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrl: './issue.component.css'
})
export class IssueComponent implements OnInit{

  constructor(private route:ActivatedRoute, private userService:UserService, private issueService:IssueService){
  }
  projectId = this.route.snapshot.params['projectId']


  ngOnInit(): void {
    
    this.getAllIssues()
  }

  getAllIssues(){
    let currentUser = this.userService.getIdFromToken()
    this.issueService.getIssues(currentUser,this.projectId).subscribe({
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
