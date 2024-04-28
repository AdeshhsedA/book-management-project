import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css','../user-login/user-login.component.css']
})
export class UserRegisterComponent {
  userData={
    email:"",
    name:"",
    password:"",
    confirmPassword:"",
    contact:0
  };
  existEmailError:string="";
  emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

  constructor(private _http:HttpClient){}

 
  OnInputName(event:any){
    this.userData.name = event.target.value;
  }

  OnInputEmail(event:any){
    this.userData.email = event.target.value;
  }

  OnInputPassword(event:any){
    this.userData.password = event.target.value;
  }

  OnInputConfirmPassword(event:any){
    this.userData.confirmPassword = event.target.value;
  }
  
  OnInputContact(event:any){
    this.userData.contact = event.target.value;
  }


  registerUser(event:any){
    event.preventDefault();
    
    if(this.userData.name.trim()==""){
      alert("Name can't be empty");
      return;
    }
    if(this.userData.email.trim()==""){
      alert("Email can't be empty");
      return;
    }
    if(!this.emailRegex.test(this.userData.email)){
      alert("Please enter valid email");
      return;
    }
    
    if(this.userData.password.length<8){
      alert("Password should be 8 characters long");
      return;
    }
    if(this.userData.confirmPassword != this.userData.password){
      alert("Password doesn't match");
      return;
    }
    if(this.userData.contact.toString().length<10){
      alert("Contact Invalid.");
      return;
    }
    this._http.post("https://localhost:7170/api/Users/Register",this.userData).subscribe(
      (response)=>{
        if(response==true){
          alert("Registered Successfully");
        }
        window.location.href="/login";
      },
      (error)=>{
        console.log(error.error);
        this.existEmailError = error.error;
        var existEmailMsg = document.getElementById('exist-email-error-message');
        console.log(existEmailMsg);
        if(existEmailMsg!= null){
          existEmailMsg.style.display = "block";
        }
        setTimeout(()=>{
          if(existEmailMsg!= null){
            existEmailMsg.style.display = "none";
          }
        },1500)
        
      }
    )
  }
}
