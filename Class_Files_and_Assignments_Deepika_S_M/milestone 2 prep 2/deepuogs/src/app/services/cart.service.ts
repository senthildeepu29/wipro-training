import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItemsSubject = new BehaviorSubject<Product[]>([]);
  cartItems$ = this.cartItemsSubject.asObservable();

  private cartCountSubject = new BehaviorSubject<number>(0);
  cartCount$ = this.cartCountSubject.asObservable();

  private cartTotalSubject = new BehaviorSubject<number>(0);
  cartTotal$ = this.cartTotalSubject.asObservable();

  addToCart(product: Product) {
    const items = this.cartItemsSubject.getValue();
    items.push(product);
    this.cartItemsSubject.next(items);
    this.updateCart();
  }

  private updateCart() {
    const items = this.cartItemsSubject.getValue();
    this.cartCountSubject.next(items.length);
    this.cartTotalSubject.next(
      items.reduce((sum, item) => sum + item.price, 0)
    );
  }

  getCartItems(): Product[] {
    return this.cartItemsSubject.getValue();
  }
}
