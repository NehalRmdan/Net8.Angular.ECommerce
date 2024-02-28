import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductItemDetailComponent } from './product-item-detail/product-item-detail.component';
import { RouterLink, RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProductItemDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterLink,
    RouterModule
  ],
  providers: [
    
  ],
  exports:[
    ShopComponent
  ]
})
export class ShopModule { }
