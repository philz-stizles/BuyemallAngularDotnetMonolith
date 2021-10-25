import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [ShopComponent, ProductItemComponent, ProductDetailComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ShopRoutingModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
