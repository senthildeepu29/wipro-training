import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service'; // adjust path as needed

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavbarComponent implements OnInit {
  cartCount: number = 0;

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cartService.items$.subscribe(items => {
      this.cartCount = items.length;
    });
  }
}
