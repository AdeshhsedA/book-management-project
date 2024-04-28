import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-admin-book-details',
  templateUrl: './admin-book-details.component.html',
  styleUrl: './admin-book-details.component.css'
})
export class AdminBookDetailsComponent {
  id:any;
  currBook:any;
  isAvailable:boolean=false;

  availableText:any;

  constructor(private _http: HttpClient, private _router: Router, private _route:ActivatedRoute){}

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

  deleteBook(){
    const confirmDelete = window.confirm("Are You Sure?");
    if(confirmDelete == true){
      console.log('deleted');
      const token = window.localStorage.getItem('token');
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      this._http.delete("https://localhost:7170/api/Books/"+this.currBook.id, 
        {headers}).subscribe(
          (response)=>{
            console.log(response);
            alert("Book Deleted Successfully...");
            this._router.navigate(['/admindashboard']);
          },(error)=>{
            console.log(error);
          }
      );
      return;
    }
    console.log('Delete Cancelled');
  }

  gotoUpdate(){
    this._router.navigate(['/updateBook', this.currBook.id]);
  }
}
