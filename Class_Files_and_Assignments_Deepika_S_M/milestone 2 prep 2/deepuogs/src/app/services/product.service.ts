import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private products: Product[] = [
    { id: 1, name: 'Top Pick Apple', description: 'Fresh apples, top pick of the month', price: 1.5, imageUrl: 'assets/images/apple.jpg', category: 'Top Recommended' },
    { id: 2, name: 'Top Pick Banana', description: 'Ripe bananas, top pick of the month', price: 0.7, imageUrl: 'assets/images/banana.jpg', category: 'Top Recommended' },
    { id: 3, name: 'Apple', description: 'Fresh apples', price: 1.2, imageUrl: 'assets/images/apple.jpg', category: 'Fruits' },
    { id: 4, name: 'Banana', description: 'Ripe bananas', price: 0.5, imageUrl: 'assets/images/banana.jpg', category: 'Fruits' }
    // Add additional mock products as needed
  ];

  getAllProducts(): Product[] {
    return this.products;
  }

  getProductsByCategory(category: string): Product[] {
    return this.products.filter(Product => Product.category === category);
  }

  getTopRecommendedProducts(): Product[] {
    return this.getProductsByCategory('Top Recommended');
  }
}
