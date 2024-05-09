import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../Services/user.service';
import { UserStoreService } from '../../../Services/user-store.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{

  public currentUsername:string = '';
  constructor(private userService:UserService, private userStore:UserStoreService) {
    
  }
  
  ngOnInit(): void {
    this.userStore.getNameFromStore().subscribe({
      next:(res)=>{
        let namefromToken = this.userService.getNameFromToken()
        this.currentUsername = res || namefromToken;
        console.log(this.currentUsername);
        
      },
      error:(err)=>{
        console.log(err);
        
      },
      complete:()=>{

      }
    })
  }

  signOut(){
    this.userService.signout();
  }
}
