// import { TestBed } from '@angular/core/testing';
// import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
// import { CouponService } from '../services/coupon.service';

// describe('CouponService', () => {
//   let service: CouponService;
//   let httpMock: HttpTestingController;

//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       imports: [HttpClientTestingModule],
//       providers: [CouponService],
//     });

//     service = TestBed.inject(CouponService);
//     httpMock = TestBed.inject(HttpTestingController);
//   });

//   afterEach(() => {
//     httpMock.verify();
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });

//   it('should fetch coupons', () => {
//     const mockCoupons = [
//       { id: 1, code: 'DISCOUNT10', discount: 10 },
//       { id: 2, code: 'SAVE20', discount: 20 }
//     ];

//     service.getCoupons().subscribe((coupons) => {
//       expect(coupons.length).toBe(2);
//       expect(coupons).toEqual(mockCoupons);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/coupons');
//     expect(req.request.method).toBe('GET');
//     req.flush(mockCoupons);
//   });

//   it('should add a coupon', () => {
//     const newCoupon = { code: 'NEW50', discount: 50 };
//     const mockResponse = { id: 3, ...newCoupon };

//     service.addCoupon(newCoupon).subscribe((res) => {
//       expect(res).toEqual(mockResponse);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/coupons');
//     expect(req.request.method).toBe('POST');
//     expect(req.request.body).toEqual(newCoupon);
//     req.flush(mockResponse);
//   });

//   it('should delete a coupon', () => {
//     const couponId = 1;
//     const mockResponse = { message: 'Coupon deleted successfully' };

//     service.deleteCoupon(couponId).subscribe((res) => {
//       expect(res).toEqual(mockResponse);
//     });

//     const req = httpMock.expectOne(`http://localhost:5000/api/coupons/${couponId}`);
//     expect(req.request.method).toBe('DELETE');
//     req.flush(mockResponse);
//   });
// });
