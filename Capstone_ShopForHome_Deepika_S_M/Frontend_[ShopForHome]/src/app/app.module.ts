import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // required for toastr
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { LoginComponent } from './components/auth/login.component';
import { RegisterComponent } from './components/auth/register.component';
import { ThankYouComponent } from './components/thank-you/thank-you.component';
import { WishlistComponent } from './components/wishlist/wishlist.component'; // ✅ import WishlistComponent
// Admin
import { AdminProductsComponent } from './components/admin/products/products1.component';
import { AdminDashboardComponent } from './components/admin/dashboard/dashboard1.component';
import { AdminOrdersComponent } from './components/admin/orders/orders1.component';
import { AdminNavbarComponent } from './components/admin/navbar/admin-navbar.component';
import { SharedModule } from './shared/shared.module';  // ✅ import SharedModule
import { CouponsComponent } from './components/admin/coupons/coupons.component';
import { AdminUsersComponent } from './components/admin/admin-users/admin-users.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductsComponent,
    CouponsComponent,
    CartComponent,
    CheckoutComponent,
    LoginComponent,
    RegisterComponent,
    ThankYouComponent,
    AdminProductsComponent,
    AdminDashboardComponent,
    AdminOrdersComponent,
    AdminNavbarComponent,
    WishlistComponent,
    AdminUsersComponent ,
    // AdminCouponsComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule, // required for toastr
    ToastrModule.forRoot() // ToastrModule added
    
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
