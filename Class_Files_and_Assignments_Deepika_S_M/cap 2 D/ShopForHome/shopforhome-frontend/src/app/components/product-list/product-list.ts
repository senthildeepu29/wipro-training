import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h2>Products</h2>
    <div *ngFor="let p of products" class="product-card">
      <h3>{{ p.name }}</h3>
      <p>{{ p.description }}</p>
      <p><b>Category:</b> {{ p.category }}</p>
      <p><b>Price:</b> ₹{{ p.price }}</p>
      <p><b>Stock:</b> {{ p.stock }}</p>
      <p><b>Rating:</b> ⭐ {{ p.rating }}</p>
    </div>
  `,
  styles: [`
    .product-card {
      border: 1px solid #ddd;
      border-radius: 8px;
      padding: 12px;
      margin: 10px 0;
      background: #fafafa;
    }
  `]
})
export class ProductListComponent implements OnInit {
  products: any[] = [];

  constructor(private ps: ProductService) {}

  ngOnInit(): void {
    this.ps.getProducts().subscribe({
      next: (data) => this.products = data,
      error: (err) => console.error('Error loading products:', err)
    });
  }
}
