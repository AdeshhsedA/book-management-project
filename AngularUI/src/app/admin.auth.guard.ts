import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('token');

    if (token) {
      // Check if the token is expired
      const tokenExpiration = this.getTokenExpiration(token);
      const role = this.getRole(token);
      if (tokenExpiration && tokenExpiration > Date.now()  && role === 'Admin') {
        return true; // User is authenticated, token is valid, and role is 'admin'
      } else {
        console.log('Unauthorized...');
      }
    }

    // User is not authenticated, token has expired, or user is not authorized, redirect to login page
    this.router.navigate(['/adminlogin']);
    return false;
  }

  private getTokenExpiration(token: string): number | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      if (payload && payload.exp) {
        return payload.exp * 1000; // Convert expiration time to milliseconds
      }
    } catch (error) {
      console.error('Error parsing JWT token payload:', error);
    }
    return null;
  }

  private getRole(token: string): string | null {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      if (payload && payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']) {
        return payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      }
    } catch (error) {
      console.error('Error parsing JWT token payload:', error);
    }
    return null;
  }
}
