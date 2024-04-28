import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-book-card',
  templateUrl: './admin-book-card.component.html',
  styleUrl: './admin-book-card.component.css'
})
export class AdminBookCardComponent {
  @Input()
  currBook:any;


  constructor(private _router:Router, private _http:HttpClient){}

  ngOnInit(){
    this.currBook.imageUrl = "https://localhost:7170"+this.currBook.imageUrl;
  }

  gotoBookDetails(){
    this._router.navigate(['/viewbookdetails/',this.currBook.id]);
  }

  gotoUpdate(){
    this._router.navigate(['/updateBook/', this.currBook.id]);
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
            window.location.reload();
          },(error)=>{
            console.log(error);
          }
      );
      return;
    }
    console.log('Delete Cancelled');
  }

}
