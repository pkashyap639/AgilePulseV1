import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrl: './issue.component.css'
})
export class IssueComponent implements OnInit{

  constructor(private route:ActivatedRoute){
  }

  ngOnInit(): void {
    let projectId = this.route.snapshot.params['projectId']
    console.log(projectId);
    
  }
}
