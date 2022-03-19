import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  baseUrl = environment.baseUrl

  constructor(private http: HttpClient) {}

  getUserOrders() {
    return this.http.get(`${this.baseUrl}/orders`)
  }

  getUserOrderDetails(id: number) {
    return this.http.get(`${this.baseUrl}/orders/${id}`)
  }
}
