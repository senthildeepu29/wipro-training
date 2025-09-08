// import { CartService } from '../services/cart.service';

// describe('CartService', () => {
//   let service: CartService;

//   beforeEach(() => {
//     localStorage.clear(); // ✅ reset storage before each test
//     service = new CartService();
//   });

//   it('should create service', () => {
//     expect(service).toBeTruthy();  // ✅ Jasmine syntax
//   });

//   it('should add item to cart', () => {
//     service.addToCart({ id: 1, name: 'Laptop', price: 1000, quantity: 1 });
//     const cart = service.getCart();
//     expect(cart.length).toBe(1);  // ✅ Jasmine syntax
//     expect(cart[0].name).toBe('Laptop');
//   });

//   it('should increase quantity if item already exists', () => {
//     service.addToCart({ id: 2, name: 'Phone', price: 500, quantity: 1 });
//     service.addToCart({ id: 2, name: 'Phone', price: 500, quantity: 2 });
//     const cart = service.getCart();
//     expect(cart[0].quantity).toBe(3);
//   });

//   it('should remove item from cart', () => {
//     service.addToCart({ id: 3, name: 'Tablet', price: 700, quantity: 1 });
//     service.removeFromCart(3);
//     const cart = service.getCart();
//     expect(cart.length).toBe(0);
//   });

//   it('should clear cart', () => {
//     service.addToCart({ id: 4, name: 'Camera', price: 2000, quantity: 1 });
//     service.clearCart();
//     const cart = service.getCart();
//     expect(cart.length).toBe(0);
//     expect(localStorage.getItem('cartItems')).toBeNull(); // ✅ Jasmine syntax
//   });

//   it('should calculate total correctly', () => {
//     service.addToCart({ id: 5, name: 'Shoes', price: 500, quantity: 2 });
//     service.addToCart({ id: 6, name: 'Bag', price: 1500, quantity: 1 });
//     const total = service.getCartTotal();
//     expect(total).toBe(2500);
//   });
// });
