import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { BooksComponent } from './user/books/books.component';
import { UserNavbarComponent } from './user/user-navbar/user-navbar.component';
import { BookDetailsComponent } from './user/books/book-details/book-details.component';
import { BookCardComponent } from './user/books/book-card/book-card.component';
import { RentedBooksComponent } from './user/rented-books/rented-books.component';
import { RentedBookCardComponent } from './user/rented-books/rented-book-card/rented-book-card.component';
import { RentedBookDetailsComponent } from './user/rented-books/rented-book-details/rented-book-details.component';
import { HttpClientModule } from '@angular/common/http';
import { ProfileComponent } from './user/profile/profile.component';
import { AdminComponent } from './admin/admin.component';
import { RouteNotExistComponent } from './route-not-exist/route-not-exist.component';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdminMenuComponent } from './admin/admin-menu/admin-menu.component';
import { AdminNavComponent } from './admin/admin-nav/admin-nav.component';
import { AdminBooksComponent } from './admin/admin-books/admin-books.component';
import { AdminBookCardComponent } from './admin/admin-books/admin-book-card/admin-book-card.component';
import { AddBookFormComponent } from './admin/admin-books/add-book-form/add-book-form.component';
import { FormsModule } from '@angular/forms';
import { AdminBookDetailsComponent } from './admin/admin-books/admin-book-details/admin-book-details.component';
import { UpdateBookFormComponent } from './admin/admin-books/update-book-form/update-book-form.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserLoginComponent,
    UserRegisterComponent,
    BooksComponent,
    UserNavbarComponent,
    BookDetailsComponent,
    BookCardComponent,
    RentedBooksComponent,
    RentedBookCardComponent,
    RentedBookDetailsComponent,
    ProfileComponent,
    AdminComponent,
    RouteNotExistComponent,
    AdminLoginComponent,
    AdminDashboardComponent,
    AdminMenuComponent,
    AdminNavComponent,
    AdminBooksComponent,
    AdminBookCardComponent,
    AddBookFormComponent,
    AdminBookDetailsComponent,
    UpdateBookFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
