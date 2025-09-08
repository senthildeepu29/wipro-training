




// src/app/services/coupon.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CouponService {
  private baseUrl = 'http://localhost:5000/api/coupons';

  constructor(private http: HttpClient) {}

  getCoupons(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  addCoupon(coupon: { code: string; discount: number }): Observable<any> {
    return this.http.post<any>(this.baseUrl, coupon);
  }

  deleteCoupon(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
}
