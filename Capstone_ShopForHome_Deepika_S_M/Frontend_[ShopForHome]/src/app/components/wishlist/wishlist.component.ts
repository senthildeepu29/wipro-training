// // import { Component, OnInit } from '@angular/core';
// // import { WishlistService } from '../../services/wishlist.service';

// // @Component({
// //   selector: 'app-wishlist',
// //   templateUrl: './wishlist.component.html',
// //   styleUrls: ['./wishlist.component.css']
// // })
// // export class WishlistComponent implements OnInit {
// //   wishlist: any[] = [];

// //   constructor(private wishlistService: WishlistService) {}

// //   ngOnInit(): void {
// //     this.wishlist = this.wishlistService.getWishlist();
// //   }

// //   removeItem(id: number) {
// //     this.wishlistService.removeFromWishlist(id);
// //     this.wishlist = this.wishlistService.getWishlist();
// //   }
// // }

// import { Component, OnInit } from '@angular/core';
// import { WishlistService } from '../../services/wishlist.service';

// @Component({
//   selector: 'app-wishlist',
//   templateUrl: './wishlist.component.html',
//   styleUrls: ['./wishlist.component.css']
// })
// export class WishlistComponent implements OnInit {
//   wishlist: any[] = [];

//   constructor(private wishlistService: WishlistService) {}

//   ngOnInit(): void {
//     this.loadWishlist();
//   }

//   loadWishlist() {
//     this.wishlist = this.wishlistService.getWishlist();
//   }

//   remove(id: number) {
//     this.wishlistService.removeFromWishlist(id);
//     this.loadWishlist(); // ✅ Refresh after remove
//   }
// }

import { Component, OnInit } from '@angular/core';
import { WishlistService } from '../../services/wishlist.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {
  wishlist: any[] = [];

  constructor(
    private wishlistService: WishlistService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.loadWishlist();
  }

  loadWishlist() {
    this.wishlist = this.wishlistService.getWishlist();
  }

  remove(id: number) {
    this.wishlistService.removeFromWishlist(id);
    this.loadWishlist(); // refresh
  }

  addToCart(product: any) {
    this.cartService.addToCart({ ...product, quantity: 1 }); // ✅ add with quantity
    alert(`${product.name} added to cart 🛒`);
    this.remove(product.id); // optional: also remove from wishlist after adding
  }
}
