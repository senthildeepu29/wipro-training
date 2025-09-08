import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {
  orders: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const email = localStorage.getItem('userEmail'); // stored on login
    if (email) {
      this.http.get<any[]>(`http://localhost:5000/api/orders/${email}`)
        .subscribe(res => this.orders = res);
    }
  }
}
