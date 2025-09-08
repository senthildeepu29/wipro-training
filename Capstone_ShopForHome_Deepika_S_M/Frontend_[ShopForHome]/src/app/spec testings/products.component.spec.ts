// import { ComponentFixture, TestBed } from '@angular/core/testing';
// import { ProductsComponent } from '../components/products/products.component';
// import { HttpClientTestingModule } from '@angular/common/http/testing';
// import { ProductService } from '../services/product.service';
// import { CartService } from '../services/cart.service';
// import { WishlistService } from '../services/wishlist.service';
// import { of } from 'rxjs';

// describe('ProductsComponent', () => {
//   let component: ProductsComponent;
//   let fixture: ComponentFixture<ProductsComponent>;
//   let productService: jasmine.SpyObj<ProductService>;
//   let cartService: jasmine.SpyObj<CartService>;
//   let wishlistService: jasmine.SpyObj<WishlistService>;

//   beforeEach(async () => {
//     const productSpy = jasmine.createSpyObj('ProductService', ['getProducts']);
//     const cartSpy = jasmine.createSpyObj('CartService', ['addToCart']);
//     const wishlistSpy = jasmine.createSpyObj('WishlistService', ['addToWishlist']);

//     await TestBed.configureTestingModule({
//       declarations: [ProductsComponent],
//       imports: [HttpClientTestingModule],
//       providers: [
//         { provide: ProductService, useValue: productSpy },
//         { provide: CartService, useValue: cartSpy },
//         { provide: WishlistService, useValue: wishlistSpy }
//       ]
//     }).compileComponents();

//     fixture = TestBed.createComponent(ProductsComponent);
//     component = fixture.componentInstance;
//     productService = TestBed.inject(ProductService) as jasmine.SpyObj<ProductService>;
//     cartService = TestBed.inject(CartService) as jasmine.SpyObj<CartService>;
//     wishlistService = TestBed.inject(WishlistService) as jasmine.SpyObj<WishlistService>;
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });

//   it('should load products on init', () => {
//     const mockProducts = [
//       { id: 1, name: 'Laptop', price: 1000, rating: 4.5, category: 'Electronics' },
//       { id: 2, name: 'Phone', price: 500, rating: 4.2, category: 'Electronics' }
//     ];
//     productService.getProducts.and.returnValue(of(mockProducts));

//     component.ngOnInit();
//     fixture.detectChanges();

//     expect(component.products.length).toBe(2);
//     expect(component.filteredProducts.length).toBe(2);
//     expect(component.categories).toContain('Electronics');
//   });

//   it('should apply filters correctly', () => {
//     component.products = [
//       { id: 1, name: 'Laptop', price: 1000, rating: 4.5, category: 'Electronics' },
//       { id: 2, name: 'Phone', price: 500, rating: 4.2, category: 'Electronics' }
//     ];
//     component.selectedCategory = 'Electronics';
//     component.maxPrice = 600;
//     component.applyFilters();

//     expect(component.filteredProducts.length).toBe(1);
//     expect(component.filteredProducts[0].name).toBe('Phone');
//   });

//   it('should call cartService when adding to cart', () => {
//     const product = { id: 1, name: 'Laptop', price: 1000, rating: 4.5, category: 'Electronics', quantity: 1 };
//     component.addToCart(product);
//     expect(cartService.addToCart).toHaveBeenCalledWith(product);
//   });

//   it('should call wishlistService when adding to wishlist', () => {
//     const product = { id: 1, name: 'Laptop', price: 1000, rating: 4.5, category: 'Electronics' };
//     component.addToWishlist(product);
//     expect(wishlistService.addToWishlist).toHaveBeenCalledWith(product);
//   });
// });
