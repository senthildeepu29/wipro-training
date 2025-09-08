// Step 3: Create Product Model
// src/app/models/product.model.ts

// typescript
export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  category: string;
}