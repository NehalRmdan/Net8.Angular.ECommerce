import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { authGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {path:'', component: HomeComponent , data: { breadcrumb: 'Home' }},
  {path:'shop',  loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule),
  data: { breadcrumb: 'Shop' }},
  {path:'basket',  loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule),
  data: { breadcrumb: 'Basket' }},
  { path:'checkout',
    canActivate: [authGuard],  
  loadChildren: () => import('./checkout/checkout.module').then(m => m.CheckoutModule),
  data: { breadcrumb: 'Check Out' 

  }},
  {path:'',  loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
  {path:'test-errors', component: TestErrorComponent,data: { breadcrumb: 'test-error' }},
  {path:'server-error', component: ServerErrorComponent,data: { breadcrumb: 'server-error' }},
  // {path:'not-found', component: NotFoundComponent,data: { breadcrumb: 'not-found' }},
   { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
