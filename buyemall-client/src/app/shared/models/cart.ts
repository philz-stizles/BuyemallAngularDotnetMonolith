export interface ICart {
    id: string
    cartItems: ICartItem[]
}

export interface ICartItem {
    id: number
    productName: string
    productBrand: string
    productCategory: string
    price: number
    imageUrl: string
    quantity: number
    brand: string
}