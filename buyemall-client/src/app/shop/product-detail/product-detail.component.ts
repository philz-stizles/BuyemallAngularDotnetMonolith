import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: IProduct
  productCount = 1

  constructor(private shopService: ShopService, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.getProduct(+this.route.snapshot.paramMap.get('id'))
  }

  getProduct(id: number) {
    this.shopService.getProduct(id)
      .subscribe(
        (response: any) => {
          console.log(response)
          this.product = response
        },
        error => {
          console.log(error)
        }
      )
  }

  setProductCount(count: number) {
    var newProductCount = this.productCount = this.productCount + count
    if(newProductCount >= 1){
      this.productCount = newProductCount
    } else {
      console.log('next')
      this.productCount = 1
    }
  }

  addToCart(id: number) {
    this.shopService.getProduct(id)
      .subscribe(
        (response: any) => {
          console.log(response)
          this.product = response
        },
        error => {
          console.log(error)
        }
      )
  }

}
