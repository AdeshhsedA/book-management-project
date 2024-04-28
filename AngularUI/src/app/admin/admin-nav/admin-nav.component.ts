import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-nav',
  templateUrl: './admin-nav.component.html',
  styleUrl: './admin-nav.component.css'
})
export class AdminNavComponent {
  toggle:boolean=false;
  toggleAuthorForm = false;
  toggleCategoryForm = false;

  author:any={
    name:""
  }

  category:any={
    name:""
  }
  constructor(private _router:Router, private _http:HttpClient){}

  toggleSideMenu(){
    const sideMenu = document.getElementById('side-menu-container');
    if(sideMenu != null){
      if(!this.toggle){
        sideMenu.style.transform = "translateX(0px)";
        this.toggle = true;
      }else{
        sideMenu.style.transform = "translateX(250px)";
        this.toggle = false;
      }
    }
  }

  toggleAddAuthor(){
    const authorForm = document.getElementById("add-author-form");
    if(authorForm != null){
      if(!this.toggleAuthorForm){
        authorForm.style.display = "block";
        this.toggleAuthorForm = true;
      }else{
        authorForm.style.display = "none";
        this.toggleAuthorForm = false;
      }
    }
  }

  toggleAddCategory(){
    const categoryForm = document.getElementById("add-category-form");
    if(categoryForm != null){
      if(!this.toggleCategoryForm){
        categoryForm.style.display = "block";
        this.toggleCategoryForm = true;
      }else{
        categoryForm.style.display = "none";
        this.toggleCategoryForm = false;
      }
    }
  }

  addAuthor(){
    if(this.author.name == ""){
      alert("Author Name Can not be empty");
      return;
    }

    const token = window.localStorage.getItem('token');
    // console.log(token);
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    this._http.post("https://localhost:7170/api/Authors/addAuthor",this.author, {headers, responseType:'text'}).subscribe(
      (res)=>{
        // console.log(res);
        alert("Author Added");
        const currUrl =  this._router.url;
        if(currUrl.includes('addbook') || currUrl.includes('updateBook')){
          window.location.reload();
        }
      },(err)=>{
        console.log(err);
        alert("Something went wrong");
      }
    );
  }

  addCategory(){
    if(this.category.name == ""){
      alert("Category Can not be empty");
      return;
    }

    const token = window.localStorage.getItem('token');
    // console.log(token);
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    this._http.post("https://localhost:7170/api/Subjects/addSubject",this.category, {headers, responseType:'text'}).subscribe(
      (res)=>{
        // console.log(res);
        alert("Category Added");
        const currUrl =  this._router.url;
        if(currUrl.includes('addbook') || currUrl.includes('updateBook')){
          window.location.reload();
        }
      },(err)=>{
        console.log(err);
        alert("Something went wrong");
      }
    );
  }


  logout(){
    window.localStorage.removeItem('token');
    this._router.navigate(['/adminlogin']);
  }
}
