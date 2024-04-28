import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rented-book-card',
  templateUrl: './rented-book-card.component.html',
  styleUrl: './rented-book-card.component.css'
})
export class RentedBookCardComponent {
  @Input()
  currRentBook:any;

  constructor(private _http: HttpClient, private _router:Router){}

  ngOnInit(){
    // console.log(this.currRentBook);
    this.currRentBook.bookImageUrl = "https://localhost:7170"+this.currRentBook.bookImageUrl;
  }

  returnBook(){
    const token = window.localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    
    this._http.post("https://localhost:7170/api/RentedBooks/returnBook/"+this.currRentBook.bookId,
     this.currRentBook.bookId, {headers, responseType:'text'}).subscribe(
      (response)=>{
        console.log(response);
        alert(`Book with Title: ${this.currRentBook.bookTitle} Returned`);
        window.location.reload();
      },(error)=>{
        console.log(error);
      }
     );
  }

}
