import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrl: './books.component.css'
})
export class BooksComponent {
  books:any;


  constructor(private _http:HttpClient){
    
  }
  
  ngOnInit(){
    this.getallBooks();
  }

  getallBooks(){
    const token = window.localStorage.getItem('token');

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    this._http.get("https://localhost:7170/api/Books", {headers}).subscribe(
      (response)=>{
        this.books = response;
      },
      (error)=>{
        console.log(error);
      }
    )
  }
}
