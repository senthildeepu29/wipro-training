export class ProductService {
  products = [{id:1,name:'Apple',price:1,category:'Fruits'}];
  getAll() { return this.products; }
}
