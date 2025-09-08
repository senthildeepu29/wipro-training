import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('token');
    if (token) {
      return true; // ✅ User is logged in
    }
    // ❌ Not logged in → redirect to login
    this.router.navigate(['/login']);
    return false;
  }
}
