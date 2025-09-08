import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { WishlistService } from '../../services/wishlist.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: any[] = [];
  filteredProducts: any[] = [];

  // 🔹 Filter options
  categories: string[] = [];
  selectedCategory: string = '';
  maxPrice: number | null = null;
  minRating: number | null = null;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private wishlistService: WishlistService
  ) {}

  ngOnInit(): void {
    this.productService.getProducts().subscribe(data => {
      this.products = data.map((p: any) => ({ ...p, quantity: 1 }));
      this.filteredProducts = [...this.products]; // initially show all
      this.categories = [...new Set(this.products.map(p => p.category))]; // unique categories
    });
  }

  // 🔹 Filtering logic
  applyFilters() {
    this.filteredProducts = this.products.filter(product => {
      const categoryMatch = !this.selectedCategory || product.category === this.selectedCategory;
      const priceMatch = !this.maxPrice || product.price <= this.maxPrice;
      const ratingMatch = !this.minRating || product.rating >= this.minRating;
      return categoryMatch && priceMatch && ratingMatch;
    });
  }

  // Quantity controls
  increase(product: any) { product.quantity++; }
  decrease(product: any) { if (product.quantity > 1) product.quantity--; }

  // Cart
  addToCart(product: any) {
    this.cartService.addToCart({ ...product, quantity: product.quantity });
    alert(`${product.name} added to cart 🛒`);
  }

  // Wishlist
  addToWishlist(product: any) {
    this.wishlistService.addToWishlist(product);
    alert(`${product.name} added to wishlist ❤️`);
  }
}
