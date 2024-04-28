import { Component } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
 
  username:any;
  email:any;

  ngOnInit(){
    this.getUser();
  }
  getUser(){
    const token = window.localStorage.getItem('token');
    if(token!=null){
      const payload = JSON.parse(atob(token.split('.')[1]));
      // console.log(atob(token.split('.')[1]));
      this.username = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
      this.email = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];

    }
  }
}
