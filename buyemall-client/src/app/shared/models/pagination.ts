import { IProduct } from "./product";

export interface IPagination {
    pageIndex: number
    pageSize: number
    data: IProduct[]
    count: number
}