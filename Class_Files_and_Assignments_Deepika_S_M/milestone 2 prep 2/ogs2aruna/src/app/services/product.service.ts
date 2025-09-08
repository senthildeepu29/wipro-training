// src/app/services/product.service.ts


import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private products: Product[] = [
    // Sample products (id, name, description, price, imageUrl, category)
    { id: 1, name: 'Apple', description: 'Fresh Red Apples', price: 2, imageUrl: 'assets/images/apple.jpg', category: 'Fruits' },
    { id: 2, name: 'Milk', description: 'Dairy milk', price: 1.5, imageUrl: 'assets/images/milk.jpg', category: 'Dairy' },
    // Add more products here
  ];

  getProducts(): Product[] {
    return this.products;
  }

  getProductsByCategory(category: string): Product[] {
    return this.products.filter(product => product.category === category);
  }
}