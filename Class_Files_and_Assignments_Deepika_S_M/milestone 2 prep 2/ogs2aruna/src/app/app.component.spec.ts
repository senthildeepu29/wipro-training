import { TestBed, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/nav-bar/nav-bar.component';

import { RouterTestingModule } from '@angular/router/testing';
import { CartService } from './services/cart.service';
import { ProductService } from './services/product.service';
import { BehaviorSubject, of } from 'rxjs';
import { Product } from './models/product.model';

// Mock CartService
class MockCartService {
  private cartItemsSubject = new BehaviorSubject<any[]>([]);
  private cartCountSubject = new BehaviorSubject<number>(0);
  private cartTotalSubject = new BehaviorSubject<number>(0);

  cartItems$ = this.cartItemsSubject.asObservable();
  cartCount$ = this.cartCountSubject.asObservable();
  cartTotal$ = this.cartTotalSubject.asObservable();

  addToCart(product: any) {
    const currentItems = this.cartItemsSubject.getValue();
    this.cartItemsSubject.next([...currentItems, product]);
    this.updateCart();
  }

  private updateCart() {
    const currentItems = this.cartItemsSubject.getValue();
    const count = currentItems.length;
    const total = currentItems.reduce((acc, item) => acc + item.price, 0);

    this.cartCountSubject.next(count);
    this.cartTotalSubject.next(total);
  }
}

// Mock ProductService
class MockProductService {
  private allProducts: Product[] = [
    { id: 1, name: 'Top Pick Apple', description: 'Fresh apples, top pick of the month', price: 1.5, imageUrl: 'assets/images/apple.jpg', category: 'Top Recommended' },
    { id: 2, name: 'Top Pick Banana', description: 'Ripe bananas, top pick of the month', price: 0.7, imageUrl: 'assets/images/banana.jpg', category: 'Top Recommended' },
    { id: 3, name: 'Apple', description: 'Fresh apples', price: 1.2, imageUrl: 'assets/images/apple.jpg', category: 'Fruits' },
    { id: 4, name: 'Banana', description: 'Ripe bananas', price: 0.5, imageUrl: 'assets/images/banana.jpg', category: 'Fruits' }
    // Add additional mock products as needed
  ];

  getAllProducts(): Product[] {
    return this.allProducts;
  }

  getProductsByCategory(category: string): Product[] {
    return this.allProducts.filter(product => product.category === category);
  }

  getTopRecommendedProducts(): Product[] {
    return this.getProductsByCategory('Top Recommended');
  }
}

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let cartService: MockCartService;
  let productService: MockProductService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent, NavbarComponent],
      imports: [RouterTestingModule],
      providers: [
        { provide: CartService, useClass: MockCartService },
        { provide: ProductService, useClass: MockProductService },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    cartService = TestBed.inject(CartService) as unknown as MockCartService;
    productService = TestBed.inject(ProductService) as unknown as MockProductService;
  });

  it('should update cart count when item is added', () => {
    const mockProduct = { id: 1, name: 'Apple', price: 100, imageUrl: '' };
    cartService.addToCart(mockProduct);

    cartService.cartCount$.subscribe(count => {
      expect(count).toBe(1);
    });
  });

  it('should update cart total when item is added', () => {
    const mockProduct = { id: 1, name: 'Apple', price: 100, imageUrl: '' };
    cartService.addToCart(mockProduct);

    cartService.cartTotal$.subscribe(total => {
      expect(total).toBe(100);
    });
  });

  it('should verify that allProducts in ProductService is not empty', () => {
    const allProducts = productService.getAllProducts();
    expect(allProducts.length).toBeGreaterThan(0);
  });

  it('should verify that removeFromCart method is not created in CartService', () => {
    expect((cartService as any).removeFromCart).toBeUndefined();
  });
  
  it('should verify that clearCart method is not created in CartService', () => {
    expect((cartService as any).clearCart).toBeUndefined();
  });
  
  it('should return products by category', () => {
    const fruits = productService.getProductsByCategory('Fruits');
    expect(fruits.length).toBeGreaterThan(0);
    expect(fruits.every(product => product.category === 'Fruits')).toBeTrue();
  });

  it('should return top recommended products', () => {
    const topRecommended = productService.getTopRecommendedProducts();
    expect(topRecommended.length).toBeGreaterThan(0);
    expect(topRecommended.every(product => product.category === 'Top Recommended')).toBeTrue();
  });  

});