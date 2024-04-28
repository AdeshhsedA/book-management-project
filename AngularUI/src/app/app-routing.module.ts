import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAuthGuard } from './admin.auth.guard';
import { AdminLoginComponent } from './admin/admin-login/admin-login.component';
import { AdminComponent } from './admin/admin.component';
import { RouteNotExistComponent } from './route-not-exist/route-not-exist.component';
import { BookDetailsComponent } from './user/books/book-details/book-details.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './userauth.guard';

const routes: Routes = [

  {
    path:'',
    redirectTo:'login',
    pathMatch:'full'
  },
  {
    path:'login',
    component:UserLoginComponent
  },
  {
    path:'register',
    component:UserRegisterComponent
  },
  {
    path:'dashboard',
    component:UserComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'bookdetails/:id',
    component:UserComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'rentedbooks',
    component:UserComponent,
    canActivate: [AuthGuard]
  },
  {
    path:'profile',
    component:UserComponent,
    canActivate: [AuthGuard]
  },{
    path:'adminlogin',
    component:AdminLoginComponent
  },{
    path:"admindashboard",
    component:AdminComponent,
    canActivate:[AdminAuthGuard]
  },{
    path:"addbook", 
    component:AdminComponent,
    canActivate:[AdminAuthGuard]
  },{
    path:"viewbookdetails/:id",
    component:AdminComponent,
    canActivate:[AdminAuthGuard]
  },{
    path:"updateBook/:id",
    component:AdminComponent,
    canActivate:[AdminAuthGuard]
  },
  
  {
    path:'**',
    component:RouteNotExistComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
