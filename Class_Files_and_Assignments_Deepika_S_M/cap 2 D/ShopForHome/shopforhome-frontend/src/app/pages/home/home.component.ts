import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product';
import { Product } from '../../models/product';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent implements OnInit {
  products: Product[] = [];

  constructor(private ps: ProductService) {}

  ngOnInit(): void {
    this.ps.getProducts().subscribe((data: Product[]) => this.products = data);
  }
}
