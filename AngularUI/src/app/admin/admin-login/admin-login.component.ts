import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrl: './admin-login.component.css'
})
export class AdminLoginComponent {
  token:any;
  userLoginData = {
    email:"",
    password:""
  };

  constructor(private _http:HttpClient, private _router:Router){
   
  }

  
  OnUpdateEmail(event:any){
    this.userLoginData.email = event.target.value;
  }

  OnUpdatePassword(event:any){
    this.userLoginData.password = event.target.value;
  }

  login(e:any){
    e.preventDefault();
    if(this.userLoginData.email.trim()=="" || this.userLoginData.password.trim()==""){
      var errorMsg= document.getElementById('empty-error-msg');
      if(errorMsg!=null){
        errorMsg.style.display="block";
      }

      setTimeout(()=>{
        if(errorMsg!=null){
          errorMsg.style.display="none";
        }
      },1000)
    }

    this._http.post("https://localhost:7170/api/Users/Login",this.userLoginData, {responseType:'text'}).subscribe(data=>{
      this.token = data;
      localStorage.setItem('token',this.token);
      const payload = JSON.parse(atob(this.token.split('.')[1]));
      if (payload && payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']) {
        const role = payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        if(role!="Admin"){
          alert("Unauhtorized");
          return;
        }
      }
      alert("Login Successful...")
      this._router.navigate(['/admindashboard']);
    },(error)=>{
      console.log(error);
      alert("Something went wrong");
    })
    console.log(this.userLoginData);
  }
}
