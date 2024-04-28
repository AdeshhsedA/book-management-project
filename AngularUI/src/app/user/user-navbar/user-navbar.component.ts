import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-navbar',
  templateUrl: './user-navbar.component.html',
  styleUrl: './user-navbar.component.css'
})
export class UserNavbarComponent {

  @Input()
  userName:any;

  constructor(private router:Router){}

  gotoDashboard(){
    this.router.navigate(['/dashboard']);
  }

  logout(){
    window.localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
