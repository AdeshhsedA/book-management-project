import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.css'
})
export class BookDetailsComponent {
  id:any;
  currBook:any;
  isAvailable:boolean=false;

  availableText = "";

  constructor(private _router:Router, private _route: ActivatedRoute, private _http:HttpClient){}

  ngOnInit(){
   this.getBook();
  }

  getAvailabilityStatus(){
    const availText = document.getElementById('available-text');
    this.isAvailable = this.currBook.isAvailable;
    if(this.currBook.isAvailable){
      this.availableText = "Available";
      
      if(availText != null){
        availText.style.color="green";
      }
      return;
    }
    this.availableText = "Un-Available";
    if(availText != null){
      availText.style.color="red";
    }
  }

  getBook(){
    this.id = this._route.snapshot.paramMap.get('id');
    const token = window.localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`);
    this._http.get("https://localhost:7170/api/Books/"+this.id, {headers}).subscribe(
      (response)=>{
        // console.log(response);
        this.currBook = response;
        this.currBook.imageUrl = "https://localhost:7170"+this.currBook.imageUrl;
        this.getAvailabilityStatus();
      },(error)=>{
        alert("Something went wrong...")
        this._router.navigate(['/dashboard']);
        console.log(error);
      }
    );
  }

  rentBook(){
    this.id = this._route.snapshot.paramMap.get('id');
    const token = window.localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    this._http.post("https://localhost:7170/api/RentedBooks/rentbook/"+this.id, this.id, {headers, responseType:'text'}).subscribe(
      (response)=>{
        alert("Book Rented Successfully...")
        this.currBook.isAvailable = false;
        this.getAvailabilityStatus();
        // console.log(response);
      },(error)=>{
        console.log(error.error);
      }
    );
  }

}
