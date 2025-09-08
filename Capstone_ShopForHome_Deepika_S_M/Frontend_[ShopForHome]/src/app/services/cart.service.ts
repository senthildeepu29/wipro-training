import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems: any[] = [];
  private cartCount = new BehaviorSubject<number>(0);
  cartCount$ = this.cartCount.asObservable();

  constructor() {
    // Load cart from localStorage if exists
    const storedCart = localStorage.getItem('cartItems');
    if (storedCart) {
      this.cartItems = JSON.parse(storedCart);
      this.cartCount.next(this.getCartItemCount());
    }
  }

  // ✅ Add item to cart
  addToCart(item: any) {
    const existingItem = this.cartItems.find(ci => ci.id === item.id);
    if (existingItem) {
      existingItem.quantity += item.quantity;
    } else {
      this.cartItems.push(item);
    }
    this.saveCart();
  }

  // ✅ Used in CartComponent
  getCart(): any[] {
    return this.cartItems;
  }

  // ✅ Used in CheckoutComponent
  getCartItems(): any[] {
    return this.cartItems;
  }

  // ✅ Quantity controls
  increaseQuantity(item: any) {
    const existingItem = this.cartItems.find(ci => ci.id === item.id);
    if (existingItem) {
      existingItem.quantity++;
      this.saveCart();
    }
  }

  decreaseQuantity(item: any) {
    const existingItem = this.cartItems.find(ci => ci.id === item.id);
    if (existingItem && existingItem.quantity > 1) {
      existingItem.quantity--;
    } else {
      this.removeFromCart(item.id);
    }
    this.saveCart();
  }

  // ✅ Remove item
  removeFromCart(itemId: number) {
    this.cartItems = this.cartItems.filter(item => item.id !== itemId);
    this.saveCart();
  }

  // ✅ Clear cart
  clearCart() {
    this.cartItems = [];
    localStorage.removeItem('cartItems');
    this.cartCount.next(0);
  }

  // ✅ Total
  getCartTotal(): number {
    return this.cartItems.reduce((acc, item) => acc + item.price * item.quantity, 0);
  }

  // ✅ Helpers
  private getCartItemCount(): number {
    return this.cartItems.reduce((acc, item) => acc + item.quantity, 0);
  }

  private saveCart() {
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
    this.cartCount.next(this.getCartItemCount());
  }
}
