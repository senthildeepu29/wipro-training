import { BehaviorSubject } from 'rxjs';
export class CartService {
  items = new BehaviorSubject<any[]>([]);
  add(p:any) { this.items.next([...this.items.value,p]); }
}
