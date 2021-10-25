import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { IProduct, IProductPagination } from '../shared/models/product';
import { IProductSpecParams } from '../shared/models/productSpecParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.baseUrl

  constructor(private http: HttpClient) { }

  getProducts(spec: IProductSpecParams) {
    let params = new HttpParams()
    Object.keys(spec).forEach(prop => {
      console.log(prop, spec[prop])
      params = params.append(prop, spec[prop])
    })

    console.log(params)

    return this.http.get<IProductPagination>(`${this.baseUrl}/Products/GetProducts`, { params })
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(`${this.baseUrl}/Products/${id}`)
  }

  getProductBrands() {
    return this.http.get<IBrand[]>(`${this.baseUrl}/Products/GetBrands`)
  }

  getProductCategories() {
    return this.http.get<ICategory[]>(`${this.baseUrl}/Products/GetCategories`)
  }

  addToCart() {
    return this.http.get<ICategory[]>(`${this.baseUrl}/basket/Create`)
  }
}
