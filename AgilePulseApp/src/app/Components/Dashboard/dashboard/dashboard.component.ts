import { Component } from '@angular/core';
import { UserService } from '../../../Services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  constructor(private userService:UserService) {
    
  }

  signOut(){
    this.userService.signout();
  }
}
