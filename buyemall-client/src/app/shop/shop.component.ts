import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { ICategory } from '../shared/models/category';
import { IProduct, IProductPagination } from '../shared/models/product';
import { IProductSpecParams } from '../shared/models/productSpecParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProductPagination
  categories: ICategory[]
  brands: IBrand[]
  spec: IProductSpecParams = {
    pageIndex: 1,
    pageSize: 10,
    categoryId: 0,
    brandId: 0,
    // sort: null,
    // search: null
  }

  constructor(private shopService: ShopService){
  }

  ngOnInit(): void {
    this.getProducts(this.spec)
    this.getProductBrands()
    this.getProductCategories()
  }

  getProducts(spec: IProductSpecParams) {
    this.shopService.getProducts(spec)
      .subscribe(
        (response: any) => {
          console.log(response)
          this.products = response
        },
        error => {
          console.log(error)
        }
      )
  }

  getProductCategories() {
    this.shopService.getProductCategories()
      .subscribe(
        (response: any) => {
          console.log(response)
          this.categories = [{id: 0, name: 'All'}, ...response]
        },
        error => {
          console.log(error)
        }
      )
  }

  getProductBrands() {
    this.shopService.getProductBrands()
      .subscribe(
        (response: any) => {
          console.log(response)
          this.brands = [{id: 0, name: 'All'}, ...response]
        },
        error => {
          console.log(error)
        }
      )
  }

  setBrandFilter(id: number) {
    this.spec.brandId = id
    this.getProducts(this.spec)
  }

  setCategoryFilter(id: number) {
    this.spec.categoryId = id
    console.log(this.spec)
    this.getProducts(this.spec)
  }

  searchProducts(e: Event) {
    const target = e.currentTarget as HTMLInputElement
    console.log(target)
    console.log(target.value)
    this.spec.search = target.value
    this.getProducts(this.spec)
  }

  previousProducts() {
    // const target = e.currentTarget as HTMLInputElement
    // console.log(target)
    // console.log(target.value)
    // this.spec.search = target.value
    this.getProducts(this.spec)
  }

  nextProducts() {
    // const target = e.currentTarget as HTMLInputElement
    // console.log(target)
    // console.log(target.value)
    // this.spec.search = target.value
    this.getProducts(this.spec)
  }
}
