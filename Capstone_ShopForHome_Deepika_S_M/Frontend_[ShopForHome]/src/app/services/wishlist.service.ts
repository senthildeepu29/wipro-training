

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  private wishlist: any[] = [];

  constructor() {
    const saved = localStorage.getItem('wishlist');
    if (saved) {
      this.wishlist = JSON.parse(saved);
    }
  }

  getWishlist() {
    return this.wishlist;
  }

  addToWishlist(product: any) {
    const exists = this.wishlist.find(p => p.id === product.id);
    if (!exists) {
      this.wishlist.push(product);
      localStorage.setItem('wishlist', JSON.stringify(this.wishlist)); // ✅ Save
      alert(`${product.name} added to wishlist ❤️`);
    } else {
      alert(`${product.name} is already in your wishlist!`);
    }
  }

  removeFromWishlist(id: number) {
    this.wishlist = this.wishlist.filter(p => p.id !== id);
    localStorage.setItem('wishlist', JSON.stringify(this.wishlist));
  }
}
