import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { CategoryComponent } from './components/category/category.component';
import { FruitsComponent } from './components/category/fruits/fruits.component';
import { VegetablesComponent } from './components/category/vegetables/vegetables.component';
import { CheeseComponent } from './components/category/cheese/cheese.component';
import { BreadComponent } from './components/category/bread/bread.component';
import { CannedGoodsComponent } from './components/category/canned-goods/canned-goods.component';
import { SnacksComponent } from './components/category/snacks/snacks.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    CartComponent,
    CheckoutComponent,
    CategoryComponent,
    FruitsComponent,
    VegetablesComponent,
    CheeseComponent,
    BreadComponent,
    CannedGoodsComponent,
    SnacksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
