import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { OrderService } from '../../services/order.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  cartItems: any[] = [];
  fullName: string = '';
  email: string = '';
  address: string = '';
  city: string = '';
  zip: string = '';
  paymentMethod: string = 'Cash on Delivery';
  couponCode: string = '';
  discount: number = 0;

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.cartItems = this.cartService.getCartItems(); // ✅ fetch items properly
  }

  getTotal(): number {
    const subtotal = this.cartItems.reduce((acc, item) => acc + (item.price * item.quantity), 0);
    return subtotal - this.discount;
  }

  applyCoupon() {
    if (this.couponCode === 'DISCOUNT10') {
      this.discount = this.getTotal() * 0.1;
      this.toastr.success('Coupon applied: 10% off');
    } else {
      this.toastr.error('Invalid coupon code');
    }
  }

  placeOrder() {
    if (this.cartItems.length === 0) {
      this.toastr.error('Your cart is empty!');
      return;
    }

    const order = {
      fullName: this.fullName,
      email: this.email,
      address: this.address,
      city: this.city,
      zip: this.zip,
      paymentMethod: this.paymentMethod,
      totalAmount: this.getTotal(),
      items: this.cartItems.map(item => ({
        productId: item.id,
        quantity: item.quantity,
        price: item.price
      }))

    };

    this.orderService.placeOrder(order).subscribe({
      next: () => {
        this.toastr.success('Order placed successfully!');
        this.cartService.clearCart(); // ✅ clear cart after order
      },
      error: () => {
        this.toastr.error('Error placing order');
      }
    });
  }
}
