// import { TestBed } from '@angular/core/testing';
// import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
// import { OrderService } from '../services/order.service';

// describe('OrderService', () => {
//   let service: OrderService;
//   let httpMock: HttpTestingController;

//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       imports: [HttpClientTestingModule],
//       providers: [OrderService],
//     });

//     service = TestBed.inject(OrderService);
//     httpMock = TestBed.inject(HttpTestingController);
//   });

//   afterEach(() => {
//     httpMock.verify();
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });

//   it('should place an order', () => {
//     const mockOrder = {
//       userId: 1,
//       fullName: 'John Doe',
//       email: 'john@example.com',
//       address: '123 Street',
//       city: 'NY',
//       zip: '10001',
//       paymentMethod: 'COD',
//       totalAmount: 500,
//       items: [
//         { productId: 1, name: 'Laptop', price: 500, quantity: 1 }
//       ]
//     };

//     const mockResponse = { message: 'Order placed successfully', orderId: 101 };

//     service.placeOrder(mockOrder).subscribe((res) => {
//       expect(res).toEqual(mockResponse);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/orders/place-order');
//     expect(req.request.method).toBe('POST');
//     expect(req.request.body).toEqual(mockOrder);
//     req.flush(mockResponse);
//   });
// });
