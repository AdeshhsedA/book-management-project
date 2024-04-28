import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  constructor(private router:Router,private _route:ActivatedRoute, private _http:HttpClient){}

 ngOnInit(){
  this.getUserName();
 }

  username:any;

  paramRoute:any;
  getUserName(){
    const token = window.localStorage.getItem('token');
    if(token!=null){
      const payload = JSON.parse(atob(token.split('.')[1]));
      this.username = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
      this.username = this.username.split(' ')[0];
    }
    
  }
  
  getUrl(){
    
    return this.router.url;
  }

  compareWithRoutePraram(){
    const currVal = this._route.snapshot.paramMap.get('id');
    if(currVal!=null){
      this.paramRoute = currVal;
    }
    return this.router.url == "/bookdetails/"+this.paramRoute;
  }
}
