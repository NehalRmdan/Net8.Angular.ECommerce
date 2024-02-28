import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductItemDetailComponent } from './shop/product-item-detail/product-item-detail.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';

const routes: Routes = [
  {path:'',redirectTo:'/home' , pathMatch : 'full'},
  {path:'shop',  loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule)},
  {path:'home', component: HomeComponent},
  {path:'**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
