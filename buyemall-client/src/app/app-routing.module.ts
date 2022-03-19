import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { AuthGuard } from './core/guards/auth.guard'
import { HomeComponent } from './home/home.component'
import { ProductDetailComponent } from './shop/product-detail/product-detail.component'

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'shop',
    loadChildren: () =>
      import(`./shop/shop.module`).then(mod => mod.ShopModule),
  },
  {
    path: 'account',
    loadChildren: () =>
      import(`./account/account.module`).then(mod => mod.AccountModule),
    data: { breadCrumb: { skip: true } },
  },
  {
    path: 'basket',
    loadChildren: () =>
      import(`./basket/basket.module`).then(mod => mod.BasketModule),
    data: { breadCrumb: 'Basket' },
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import(`./orders/orders.module`).then(mod => mod.OrdersModule),
    data: { breadCrumb: 'Orders' },
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
