import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart() {
    this.cartItems = this.cartService.getCart();
  }

  increase(item: any) {
    this.cartService.increaseQuantity(item);
    this.loadCart();
  }

  decrease(item: any) {
    this.cartService.decreaseQuantity(item);
    this.loadCart();
  }

  remove(item: any) {
    this.cartService.removeFromCart(item);
    this.loadCart();
  }

  getTotal(): number {
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }
}
