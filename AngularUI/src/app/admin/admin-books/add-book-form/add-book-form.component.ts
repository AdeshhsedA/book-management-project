import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-book-form',
  templateUrl: './add-book-form.component.html',
  styleUrls: ['./add-book-form.component.css']
})
export class AddBookFormComponent {
  authors:any;
  categories:any;
  book:any={
    isbn: 0,
    title: "",
    description: "",
    bookShelfNo: 0,
    shelfRowNo: 0,
    isAvailable: true,
    imageUrl:"",
    authorId: 0,
    subjectId: 0
  };

  file:any;
  constructor(private _http:HttpClient, private _router:Router){}

  ngOnInit(){
    this.resetTextArea();
    this.getAuthors();
    this.getCategories();
  }

  resetTextArea(){
    const textarea = document.getElementById('description');
    if(textarea != null){
      textarea.innerHTML = "";
    }
  }

  getAuthors(){
    const token = window.localStorage.getItem('token');
    
    const headers = new HttpHeaders().set("Authorization",`Bearer ${token}`);
    this._http.get("https://localhost:7170/api/Authors",{headers}).subscribe(
      (response)=>{
        this.authors=response;
        // console.log(response);
      },(error)=>{
        console.log(error);
      }
    );
  }

  getCategories(){
    const token = window.localStorage.getItem('token');
    
    const headers = new HttpHeaders().set("Authorization",`Bearer ${token}`);
    this._http.get("https://localhost:7170/api/Subjects",{headers}).subscribe(
      (response)=>{
        this.categories=response;
        // console.log(response);
      },(error)=>{
        console.log(error);
      }
    );
  }


  setBookISBN(event:any){
    this.book.isbn = event.target.value;
  }

  setBookTitle(event:any){
    this.book.title = event.target.value;
  }

  setBookDescription(event:any){
    this.book.description = event.target.value;
  }

  setBookStatus(event:any){
    this.book.isAvailable = event.target.value;
  }

  setBookShelfNo(event:any){
    this.book.bookShelfNo = event.target.value;
  }

  setBookShelfRowNo(event:any){
    this.book.shelfRowNo = event.target.value;
  }

  getSelectedCategory(event:any){
    this.book.subjectId = event.target.value;
  }

  getSelectedAuthor(event:any){
    this.book.authorId = event.target.value;
  }

  onChangeFile(event:any){
    if(event.target.files.length > 0){
      this.file = event.target.files[0];
      if(this.file.type == 'image/png' || this.file.type == 'image/jpeg'){
        const formData = new FormData();
        formData.append('file',this.file);
        const headers = new HttpHeaders().append('Content-Disposition', 'multipart/form-data');
        this._http.post('https://localhost:7170/api/Books/uploadFile',formData, {headers, responseType:'text'}).subscribe((res)=>{
          // console.log(res);
          this.book.imageUrl = res;
        },(err)=>{
          console.log(err);
        });
      }else{
        alert("Select File of jpg or png only")
      }
      
    }
    
  }

  addBook(event:any){
    if(this.book.isbn.length>12){
      alert("ISBN should only contain 12 or less digits");
      return;
    }
    this.book.isbn = parseInt(this.book.isbn);
    this.book.bookShelfNo = parseInt(this.book.bookShelfNo);
    this.book.shelfRowNo = parseInt(this.book.shelfRowNo);
    this.book.authorId = parseInt(this.book.authorId);
    this.book.subjectId = parseInt(this.book.subjectId);
    if(this.book.title==''){
      alert("Book title can't be empty");
      return;
    }
    if(this.book.isbn==0 ){
      alert("ISBN can't be 0");
      return;
    }
    if(this.book.authorId <= 0){
      alert('Please select Author');
      return;
    }
    if(this.book.subjectId <= 0){
      alert('Please select Category');
      return;
    }
    if(this.book.imageUrl==""){
      alert('Please select an image file');
      return;
    }
    if(this.book.bookShelfNo <= 0){
      alert('Please select Book Shelf Number');
      return;
    }
    if(this.book.shelfRowNo <= 0){
      alert('Please select Shelf Row Number');
      return;
    }
    
    if(this.book.description.trim().length<50){
      alert("Description must contain 50 or more characters");
      return;
    }

    const token = window.localStorage.getItem('token');
    
    const headers = new HttpHeaders().set("Authorization",`Bearer ${token}`);
    // console.log(this.book);
    this._http.post("https://localhost:7170/api/Books/AddBook", this.book, {headers, responseType:'text'}).subscribe(
      (response)=>{
        // console.log(response);
        alert("Success...");
        this._router.navigate(['/admindashboard']);
      },(error)=>{
        console.log(error);
      }
    );
  }
}
