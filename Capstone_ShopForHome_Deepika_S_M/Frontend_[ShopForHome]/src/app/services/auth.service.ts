import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private baseUrl = 'http://localhost:5000/api/auth'; // backend URL

  constructor(private http: HttpClient) {}

  // ✅ FIX: only one payload argument
  login(payload: { email: string; password: string }): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/login`, payload).pipe(
      tap((user) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user)); // save user + role
        }
      })
    );
  }

  register(payload: { fullName: string; email: string; password: string }): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, payload);
  }

  getUserRole(): string {
    const user = localStorage.getItem('user');
    if (user) {
      return JSON.parse(user).role;
    }
    return '';
  }

  logout() {
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('user');
  }
}
