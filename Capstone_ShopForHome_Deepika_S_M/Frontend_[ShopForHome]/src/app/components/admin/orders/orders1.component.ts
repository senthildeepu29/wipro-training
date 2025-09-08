import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './orders1.component.html',
  styleUrls: ['./orders1.component.css']
})
export class AdminOrdersComponent implements OnInit {
  orders: any[] = [];
  private baseUrl = 'http://localhost:5000/api/orders';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  // ✅ Load all orders
  loadOrders() {
    this.http.get<any[]>(this.baseUrl).subscribe({
      next: (data) => (this.orders = data),
      error: (err) => console.error('❌ Error loading orders:', err)
    });
  }

updateStatus(order: any, status: string) {
  const body = { status: status };
  this.http.put(`${this.baseUrl}/${order.id}`, body).subscribe({
    next: () => {
      alert(`✅ Order #${order.id} updated to ${status}`);
      order.status = status; // update locally
    },
    error: (err) => console.error('❌ Error updating order:', err)
  });
}


// Delete order
deleteOrder(id: number) {
  if (confirm('Are you sure you want to delete this order?')) {
    this.http.delete(`${this.baseUrl}/${id}`).subscribe({
      next: () => {
        alert(`🗑️ Order #${id} deleted!`);
        // ✅ Remove the deleted order from table without reloading
        this.orders = this.orders.filter(o => o.id !== id);
      },
      error: (err) => console.error('❌ Error deleting order:', err)
    });
  }
}
}

  

