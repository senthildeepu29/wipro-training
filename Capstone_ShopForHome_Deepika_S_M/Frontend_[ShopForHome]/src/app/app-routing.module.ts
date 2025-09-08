import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/auth/login.component';
import { RegisterComponent } from './components/auth/register.component';
import { ProductsComponent } from './components/products/products.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { ThankYouComponent } from './components/thank-you/thank-you.component';
import { WishlistComponent } from './components/wishlist/wishlist.component';
// ✅ Admin components
import { AdminDashboardComponent } from './components/admin/dashboard/dashboard1.component';
import { AdminProductsComponent } from './components/admin/products/products1.component';
import { AdminOrdersComponent } from './components/admin/orders/orders1.component';
import { CouponsComponent } from './components/admin/coupons/coupons.component'; // ✅ import
import { AdminUsersComponent } from './components/admin/admin-users/admin-users.component'; // ✅ import
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'cart', component: CartComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'thank-you', component: ThankYouComponent },
  { path: 'wishlist', component: WishlistComponent },

  // ✅ Admin Routes
  { path: 'admin/dashboard', component: AdminDashboardComponent },
  { path: 'admin/products', component: AdminProductsComponent },
  { path: 'admin/orders', component: AdminOrdersComponent },
  { path: 'admin/coupons', component: CouponsComponent }, // ✅ Coupons page
  { path: 'admin/users', component: AdminUsersComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
