import { CartService } from './cart.service';  // Adjust the path if needed
import { Component } from '@angular/core';
import { AppComponent} from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  count = 0;
  constructor(cart: CartService) {
    cart.items.subscribe(i => this.count = i.length);
  }
}
