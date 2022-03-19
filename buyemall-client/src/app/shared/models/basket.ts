import { v4 as uuidv4 } from 'uuid'

export interface IBasket {
  id: string
  items: IBasketItem[]
  clientSecret?: string
  paymentIntentId?: string
  deliveryMethodId?: number
}

export interface IBasketItem {
  id: number
  productName: string
  price: number
  quantity: number
  pictureUrl: string
  category: string
  brand: string
}

export class Basket implements IBasket {
  id = uuidv4()
  items: IBasketItem[]
}
