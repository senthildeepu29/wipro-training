import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-products',
  templateUrl: './products1.component.html',
  styleUrls: ['./products1.component.css']
})
export class AdminProductsComponent implements OnInit {
  products: any[] = [];
  filteredProducts: any[] = [];
  categories: string[] = [];   // ✅ unique categories

  // New product form
  newProduct: any = {
    id: 0,
    name: '',
    price: 0,
    rating: 0,
    imageUrl: '',
    category: '',
    stock: 0
  };

  editingProduct: any = null;

  // Filters
  searchTerm: string = '';
  filterCategory: string = '';

  private baseUrl = 'http://localhost:5000/api/products';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  // ✅ Load products and categories
  loadProducts() {
    this.http.get<any[]>(this.baseUrl).subscribe({
      next: (data) => {
        this.products = data;
        this.filteredProducts = data;
        this.categories = [...new Set(data.map(p => p.category).filter(c => c))];
      },
      error: (err) => console.error('Error loading products', err)
    });
  }

  // ✅ Search & filter
  applyFilters() {
    this.filteredProducts = this.products.filter(p => {
      const matchesSearch = this.searchTerm
        ? p.name.toLowerCase().includes(this.searchTerm.toLowerCase())
        : true;

      const matchesCategory = this.filterCategory
        ? p.category.toLowerCase() === this.filterCategory.toLowerCase()
        : true;

      return matchesSearch && matchesCategory;
    });
  }

  // ✅ Add product
  addProduct() {
    this.http.post(this.baseUrl, this.newProduct).subscribe({
      next: () => {
        alert('✅ Product added successfully!');
        this.newProduct = { id: 0, name: '', price: 0, rating: 0, imageUrl: '', category: '', stock: 0 };
        this.loadProducts();
      },
      error: (err) => console.error('Error adding product', err)
    });
  }

  editProduct(product: any) {
    this.editingProduct = { ...product };
  }

  updateProduct() {
    if (!this.editingProduct) return;
    this.http.put(`${this.baseUrl}/${this.editingProduct.id}`, this.editingProduct).subscribe({
      next: () => {
        alert('✏️ Product updated successfully!');
        this.editingProduct = null;
        this.loadProducts();
      },
      error: (err) => console.error('Error updating product', err)
    });
  }

  cancelEdit() {
    this.editingProduct = null;
  }

  deleteProduct(id: number) {
    if (confirm('Are you sure you want to delete this product?')) {
      this.http.delete(`${this.baseUrl}/${id}`).subscribe({
        next: () => {
          alert('🗑️ Product deleted!');
          this.loadProducts();
        },
        error: (err) => console.error('Error deleting product', err)
      });
    }
  }
}
