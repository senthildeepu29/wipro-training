// // // // // import { Component, OnInit } from '@angular/core';
// // // // // import { CouponService } from '../../../services/coupon.service';

// // // // // @Component({
// // // // //   selector: 'app-admin-coupons',
// // // // //   templateUrl: './coupons.component.html',
// // // // //   styleUrls: ['./coupons.component.css']
// // // // // })
// // // // // export class CouponsComponent implements OnInit {
// // // // //   code: string = '';
// // // // //   discount: number = 0;
// // // // //   coupons: any[] = [];

// // // // //   constructor(private couponService: CouponService) {}

// // // // //   ngOnInit(): void {
// // // // //     this.loadCoupons();
// // // // //   }

// // // // //   loadCoupons() {
// // // // //     this.couponService.getCoupons().subscribe({
// // // // //       next: (data) => (this.coupons = data),
// // // // //       error: (err) => console.error('❌ Error loading coupons:', err)
// // // // //     });
// // // // //   }

// // // // //   addCoupon() {
// // // // //     if (!this.code || this.discount <= 0) {
// // // // //       alert('⚠️ Please enter valid code and discount');
// // // // //       return;
// // // // //     }

// // // // //     const coupon = { code: this.code, discount: this.discount };
// // // // //     this.couponService.addCoupon(coupon).subscribe({
// // // // //       next: () => {
// // // // //         alert('✅ Coupon added!');
// // // // //         this.code = '';
// // // // //         this.discount = 0;
// // // // //         this.loadCoupons();
// // // // //       },
// // // // //       error: (err) => console.error('❌ Error adding coupon:', err)
// // // // //     });
// // // // //   }

// // // // //   deleteCoupon(id: number) {
// // // // //     if (confirm('Are you sure you want to delete this coupon?')) {
// // // // //       this.couponService.deleteCoupon(id).subscribe({
// // // // //         next: () => {
// // // // //           alert('🗑️ Coupon deleted!');
// // // // //           this.loadCoupons();
// // // // //         },
// // // // //         error: (err) => console.error('❌ Error deleting coupon:', err)
// // // // //       });
// // // // //     }
// // // // //   }
// // // // // }

// // // // // import { Injectable } from '@angular/core';
// // // // // import { HttpClient } from '@angular/common/http';
// // // // // import { Observable } from 'rxjs';

// // // // // @Injectable({ providedIn: 'root' })
// // // // // export class CouponService {
// // // // //   private baseUrl = 'http://localhost:5000/api/coupons';

// // // // //   constructor(private http: HttpClient) {}

// // // // //   // Get all coupons
// // // // //   getCoupons(): Observable<any[]> {
// // // // //     return this.http.get<any[]>(this.baseUrl);
// // // // //   }

// // // // //   // ✅ Add a new coupon
// // // // //   addCoupon(coupon: { code: string; discount: number }): Observable<any> {
// // // // //     return this.http.post<any>(this.baseUrl, coupon);
// // // // //   }

// // // // //   // ✅ Delete coupon by ID
// // // // //   deleteCoupon(id: number): Observable<any> {
// // // // //     return this.http.delete(`${this.baseUrl}/${id}`);
// // // // //   }

// // // // //   // (Optional) Update coupon
// // // // //   updateCoupon(id: number, coupon: { code: string; discount: number }): Observable<any> {
// // // // //     return this.http.put(`${this.baseUrl}/${id}`, coupon);
// // // // //   }
// // // // // }

// // // // import { Component, OnInit } from '@angular/core';
// // // // import { CouponService } from '../../../services/coupon.service';

// // // // @Component({
// // // //   selector: 'app-admin-coupons',
// // // //   templateUrl: './coupons.component.html',
// // // //   styleUrls: ['./coupons.component.css']
// // // // })
// // // // export class AdminCouponsComponent implements OnInit {
// // // //   coupons: any[] = [];
// // // //   code: string = '';
// // // //   discount: number = 0;

// // // //   constructor(private couponService: CouponService) {}

// // // //   ngOnInit(): void {
// // // //     this.loadCoupons();
// // // //   }

// // // //   loadCoupons() {
// // // //     this.couponService.getCoupons().subscribe({
// // // //       next: (data) => (this.coupons = data),
// // // //       error: (err) => console.error('Error loading coupons', err)
// // // //     });
// // // //   }

// // // //   addCoupon() {
// // // //     const coupon = { code: this.code, discount: this.discount };
// // // //     this.couponService.addCoupon(coupon).subscribe({
// // // //       next: () => {
// // // //         alert('✅ Coupon added!');
// // // //         this.code = '';
// // // //         this.discount = 0;
// // // //         this.loadCoupons();
// // // //       },
// // // //       error: (err) => console.error('Error adding coupon', err)
// // // //     });
// // // //   }

// // // //   deleteCoupon(id: number) {
// // // //     if (confirm('Are you sure you want to delete this coupon?')) {
// // // //       this.couponService.deleteCoupon(id).subscribe({
// // // //         next: () => {
// // // //           alert('🗑️ Coupon deleted!');
// // // //           this.loadCoupons();
// // // //         },
// // // //         error: (err) => console.error('Error deleting coupon', err)
// // // //       });
// // // //     }
// // // //   }
// // // // }

// // // import { Injectable } from '@angular/core';
// // // import { HttpClient } from '@angular/common/http';
// // // import { Observable } from 'rxjs';

// // // @Injectable({ providedIn: 'root' })
// // // export class CouponService {
// // //   private baseUrl = 'http://localhost:5000/api/coupons';

// // //   constructor(private http: HttpClient) {}

// // //   // ✅ Get all coupons
// // //   getCoupons(): Observable<any[]> {
// // //     return this.http.get<any[]>(this.baseUrl);
// // //   }

// // //   // ✅ Add new coupon
// // //   addCoupon(coupon: { code: string; discount: number }): Observable<any> {
// // //     return this.http.post<any>(this.baseUrl, coupon);
// // //   }

// // //   // ✅ Delete coupon
// // //   deleteCoupon(id: number): Observable<any> {
// // //     return this.http.delete(`${this.baseUrl}/${id}`);
// // //   }
// // // }




// // import { Component } from '@angular/core';
// // import { CouponService } from '../../../services/coupon.service';

// // @Component({
// //   selector: 'app-admin-coupons',
// //   templateUrl: './coupons.component.html',
// //   styleUrls: ['./coupons.component.css']
// // })
// // export class AdminCouponsComponent {
// //   code = '';
// //   discount = 0;
// //   coupons: any[] = [];

// //   constructor(private couponService: CouponService) {}

// //   ngOnInit() {
// //     this.loadCoupons();
// //   }

// //   loadCoupons() {
// //     this.couponService.getCoupons().subscribe({
// //       next: (data) => (this.coupons = data),
// //       error: (err) => console.error(err)
// //     });
// //   }

// //   addCoupon() {
// //     if (!this.code || !this.discount) return;

// //     this.couponService.addCoupon({ code: this.code, discount: this.discount }).subscribe({
// //       next: () => {
// //         this.code = '';
// //         this.discount = 0;
// //         this.loadCoupons();
// //       },
// //       error: (err) => console.error(err)
// //     });
// //   }

// //   deleteCoupon(id: number) {
// //     this.couponService.deleteCoupon(id).subscribe({
// //       next: () => this.loadCoupons(),
// //       error: (err) => console.error(err)
// //     });
// //   }
// // }

// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';

// @Injectable({ providedIn: 'root' })
// export class CouponService {
//   private baseUrl = 'http://localhost:5000/api/coupons';

//   constructor(private http: HttpClient) {}

//   getCoupons(): Observable<any[]> {
//     return this.http.get<any[]>(this.baseUrl);
//   }

//   addCoupon(coupon: { code: string; discount: number }): Observable<any> {
//     return this.http.post<any>(this.baseUrl, coupon);
//   }

//   deleteCoupon(id: number): Observable<any> {
//     return this.http.delete<any>(`${this.baseUrl}/${id}`);
//   }
// }
// export class CouponsComponent {

// }



// src/app/components/admin/coupons/coupons.component.ts
import { Component, OnInit } from '@angular/core';
import { CouponService } from '../../../services/coupon.service';

@Component({
  selector: 'app-coupons',
  templateUrl: './coupons.component.html',
  styleUrls: ['./coupons.component.css']
})
export class CouponsComponent implements OnInit {
  coupons: any[] = [];
  code = '';
  discount = 0;

  constructor(private couponService: CouponService) {}

  ngOnInit(): void {
    this.loadCoupons();
  }

  loadCoupons() {
    this.couponService.getCoupons().subscribe(data => {
      this.coupons = data;
    });
  }

  addCoupon() {
    const coupon = { code: this.code, discount: this.discount };
    this.couponService.addCoupon(coupon).subscribe(() => {
      this.loadCoupons();
      this.code = '';
      this.discount = 0;
    });
  }

  deleteCoupon(id: number) {
    this.couponService.deleteCoupon(id).subscribe(() => {
      this.loadCoupons();
    });
  }
}
