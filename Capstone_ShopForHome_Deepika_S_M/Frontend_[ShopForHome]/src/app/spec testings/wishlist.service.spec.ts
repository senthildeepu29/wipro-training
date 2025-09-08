// import { TestBed } from '@angular/core/testing';
// import { WishlistService } from '../services/wishlist.service';

// describe('WishlistService', () => {
//   let service: WishlistService;

//   beforeEach(() => {
//     // Clear localStorage before each test
//     localStorage.clear();
//     TestBed.configureTestingModule({});
//     service = TestBed.inject(WishlistService);
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });

//   it('should start with empty wishlist', () => {
//     expect(service.getWishlist().length).toBe(0);
//   });

//   it('should add product to wishlist', () => {
//     const product = { id: 1, name: 'Laptop' };

//     spyOn(window, 'alert'); // ✅ prevent real alerts during tests
//     service.addToWishlist(product);

//     const wishlist = service.getWishlist();
//     expect(wishlist.length).toBe(1);
//     expect(wishlist[0]).toEqual(product);
//     expect(localStorage.getItem('wishlist')).toContain('Laptop');
//   });

//   it('should not add duplicate product', () => {
//     const product = { id: 1, name: 'Laptop' };

//     spyOn(window, 'alert');
//     service.addToWishlist(product);
//     service.addToWishlist(product); // duplicate

//     expect(service.getWishlist().length).toBe(1);
//   });

//   it('should remove product from wishlist', () => {
//     const product = { id: 1, name: 'Laptop' };

//     spyOn(window, 'alert');
//     service.addToWishlist(product);
//     service.removeFromWishlist(1);

//     expect(service.getWishlist().length).toBe(0);
//     expect(localStorage.getItem('wishlist')).toBe('[]');
//   });
// });
