import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  base = environment.apiUrl + '/users';
  tokenKey = 'shop_token';
  constructor(private http: HttpClient) {}
  register(data: any) { return this.http.post(`${this.base}/register`, data); }
  login(credentials: any) { return this.http.post(`${this.base}/login`, credentials).pipe(tap((res:any)=> { localStorage.setItem(this.tokenKey, res.token); })); }
  getToken() { return localStorage.getItem(this.tokenKey); }
  logout(){ localStorage.removeItem(this.tokenKey); }
}
