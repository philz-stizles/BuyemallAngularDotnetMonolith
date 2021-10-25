import { IPagination } from "./pagination";

export interface IProduct {
    id: number
    name: string
    description: string
    price: number
    imageUrl: string
    category: string
    brand: string
}

export interface IProductPagination extends IPagination {
    data: IProduct[]
}