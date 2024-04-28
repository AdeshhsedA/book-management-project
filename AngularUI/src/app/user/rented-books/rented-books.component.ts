import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-rented-books',
  templateUrl: './rented-books.component.html',
  styleUrl: './rented-books.component.css'
})
export class RentedBooksComponent {
  rentedbooks:any;
  constructor(private _http:HttpClient){}

  ngOnInit(){
    this.getRentedbooksByUser();
  }

  getRentedbooksByUser(){
    const token = window.localStorage.getItem('token');

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this._http.get("https://localhost:7170/api/RentedBooks/UserRentedDetails",{headers}).subscribe(
      (response)=>{
        // console.log(response);
        this.rentedbooks = response;
      },(error)=>{
        console.log(error);
      }
    );
  }

}
