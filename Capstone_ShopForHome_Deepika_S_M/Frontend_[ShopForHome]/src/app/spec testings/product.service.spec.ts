// import { TestBed } from '@angular/core/testing';
// import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
// import { ProductService } from '../services/product.service';

// describe('ProductService', () => {
//   let service: ProductService;
//   let httpMock: HttpTestingController;

//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       imports: [HttpClientTestingModule],
//       providers: [ProductService],
//     });

//     service = TestBed.inject(ProductService);
//     httpMock = TestBed.inject(HttpTestingController);
//   });

//   afterEach(() => {
//     httpMock.verify();
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });

//   it('should fetch all products', () => {
//     const mockProducts = [
//       { id: 1, name: 'Laptop', price: 1200 },
//       { id: 2, name: 'Phone', price: 800 },
//     ];

//     service.getProducts().subscribe((products) => {
//       expect(products.length).toBe(2);
//       expect(products).toEqual(mockProducts);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/products');
//     expect(req.request.method).toBe('GET');
//     req.flush(mockProducts);
//   });

//   it('should fetch product by id', () => {
//     const mockProduct = { id: 1, name: 'Laptop', price: 1200 };

//     service.getProduct(1).subscribe((product) => {
//       expect(product).toEqual(mockProduct);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/products/1');
//     expect(req.request.method).toBe('GET');
//     req.flush(mockProduct);
//   });
// });
