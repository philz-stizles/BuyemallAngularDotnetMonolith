import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { BehaviorSubject } from 'rxjs'
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment'
import { Basket, IBasket, IBasketItem } from '../shared/models/basket'
import { IProduct } from '../shared/models/product'

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseUrl = environment.baseUrl
  private basketSource = new BehaviorSubject<IBasket>(null)
  basket$ = this.basketSource.asObservable()

  constructor(private http: HttpClient) {}

  getBasket(id: string) {
    return this.http.get(`${this.baseUrl}/Basket?id=${id}`).pipe(
      map((basket: IBasket) => {
        this.basketSource.next(basket)
      })
    )
  }

  setBasket(basket: IBasket) {
    return this.http.post(`${this.baseUrl}/Basket`, basket).subscribe(
      (response: IBasket) => {
        this.basketSource.next(response)
      },
      error => {
        console.log(error)
      }
    )
  }

  getCurrentBasketValue() {
    return this.basketSource.value
  }

  addItemToBasket(product: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductToBasketItem(
      product,
      quantity
    )
    const basket = this.getCurrentBasketValue() ?? this.createBasket()
    basket.items = this.addOrUpdateBasketItems(
      basket.items,
      itemToAdd,
      quantity
    )
    this.setBasket(basket)
  }
  private addOrUpdateBasketItems(
    items: IBasketItem[],
    itemToAdd: IBasketItem,
    quantity: number
  ): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id)
    if (index === -1) {
      itemToAdd.quantity = quantity
      items.push(itemToAdd)
    } else {
      items[index].quantity += quantity
    }

    return items
  }

  private createBasket(): IBasket {
    const basket = new Basket()
    localStorage.setItem('basket_id', basket.id)
    return basket
  }

  private mapProductToBasketItem(
    product: IProduct,
    quantity: number
  ): IBasketItem {
    return {
      id: product.id,
      productName: product.name,
      price: product.price,
      quantity,
      brand: product.brand,
      category: product.category,
      pictureUrl: product.imageUrl,
    }
  }
}
