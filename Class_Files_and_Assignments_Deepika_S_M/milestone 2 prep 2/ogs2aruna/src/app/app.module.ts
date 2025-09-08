import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';
import { TopRecommendedComponent } from './components/top-recommended/top-recommended.component';
import { FruitsComponent } from './components/fruits/fruits.component';
import { VegetablesComponent } from './components/vegetables/vegetables.component';
import { DairyComponent } from './components/dairy/dairy.component';
import { SnacksComponent } from './components/snacks/snacks.component';
import { CheeseComponent } from './components/cheese/cheese.component';
import { BreadComponent } from './components/bread/bread.component';
import { CannedGoodsComponent } from './components/canned-goods/canned-goods.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    TopRecommendedComponent,
    FruitsComponent,
    VegetablesComponent,
    DairyComponent,
    SnacksComponent,
    CheeseComponent,
    BreadComponent,
    CannedGoodsComponent,
    CartComponent,
    CheckoutComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
