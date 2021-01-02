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

interface IProductPagination extends IPagination {
    data: IProduct[]
}