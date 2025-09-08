import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';  // adjust the path if needed

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItemsSubject = new BehaviorSubject<Product[]>([]);
  private cartCountSubject = new BehaviorSubject<number>(0);

  public items$ = this.cartItemsSubject.asObservable();
  public cartCount$ = this.cartCountSubject.asObservable();

  constructor() {
    const savedCart = localStorage.getItem('cart');
    if (savedCart) {
      const parsedItems = JSON.parse(savedCart);
      this.cartItemsSubject.next(parsedItems);
      this.cartCountSubject.next(parsedItems.length);
    }
  }

  addToCart(product: Product): void {
    const currentItems = this.cartItemsSubject.value;
    const updatedItems = [...currentItems, product];
    this.cartItemsSubject.next(updatedItems);
    this.updateCartState(updatedItems);
  }

  removeFromCart(productId: number): void {
    const updatedItems = this.cartItemsSubject.value.filter(item => item.id !== productId);
    this.cartItemsSubject.next(updatedItems);
    this.updateCartState(updatedItems);
  }

  clearCart(): void {
    this.cartItemsSubject.next([]);
    this.updateCartState([]);
  }

  getCartItems(): Product[] {
    return this.cartItemsSubject.value;
  }

  private updateCartState(items: Product[]): void {
    this.cartCountSubject.next(items.length);
    localStorage.setItem('cart', JSON.stringify(items));
  }
}
