import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductItemDetailComponent } from './product-item-detail/product-item-detail.component';
const routes: Routes = [
  
    {path:'', component: ShopComponent},
    {path:':id', component: ProductItemDetailComponent,  data: {
      breadcrumb: {
        alias: 'productDetails'
      }
    }
}, 
  
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShopRoutingModule { }