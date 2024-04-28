import { HttpClient } from '@angular/common/http';
import { Component , Input} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-card',
  templateUrl: './book-card.component.html',
  styleUrl: './book-card.component.css'
})
export class BookCardComponent {
  @Input()
  book:any;

  currBook:any;
  constructor(private _router: Router, private _http:HttpClient){}
  

  ngOnInit(){
    // console.log("init");
    this.book.imageUrl = "https://localhost:7170"+this.book.imageUrl;
  }

  gotoBookDetails(){
    // console.log(this.book);
    this._router.navigate(['/bookdetails'])
    this._router.navigate(['/bookdetails/',this.book.id]);
  }

}
