import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  paramRoute:any;
  constructor(private _router:Router, private _route:ActivatedRoute, private _http:HttpClient){}
  
  getUrl(){
    return this._router.url;
  }

  compareWithRoutePraram(){
    const currVal = this._route.snapshot.paramMap.get('id');
    if(currVal!=null){
      this.paramRoute = currVal;
    }
    return this._router.url == "/viewbookdetails/"+this.paramRoute;
  }

  compareWithRoutePraramUpdate(){
    const currVal = this._route.snapshot.paramMap.get('id');
    if(currVal!=null){
      this.paramRoute = currVal;
    }
    // console.log(this._router.url == "/updatebookdetails/"+this.paramRoute);
    return this._router.url == "/updateBook/"+this.paramRoute;
  }

  
}
