import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {
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
      alert("Login Successful...")
      this._router.navigate(['/dashboard']);
    },(error)=>{
      console.log(error);
      alert("Something went wrong...");
    })
    console.log(this.userLoginData);
  }
}
