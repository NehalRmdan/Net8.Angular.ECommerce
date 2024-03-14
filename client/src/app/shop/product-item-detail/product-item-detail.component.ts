import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shop.service';
import { IProduct } from '../../shared/Models/IProduct';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-item-detail',
  templateUrl: './product-item-detail.component.html',
  styleUrl: './product-item-detail.component.scss'
})
export class ProductItemDetailComponent implements OnInit {

  product: IProduct| undefined;

  constructor(private _shopService : ShopService,
              private _route: ActivatedRoute,
             private _bcService: BreadcrumbService,
             private basketService: BasketService)
  {

  }

  quantity=1;

  ngOnInit(): void {

    let id=+(this._route.snapshot.paramMap.get('id')?? 0);
  
    this._shopService.getProduct(id).subscribe({
      next: response => { this.product = response;  this._bcService.set('@productDetails', this.product.name); },
      error: err => { console.log(" error in product item.")}
    })
  }

  
  AddItemToBasket()
  {
    if(this.product)
      this.basketService.addItemToBasket(this.product,this.quantity);

  }

  incrementQuantity()
  {
    this.quantity++;
  }

  decrementQuantity()
  {
    if(this.quantity > 1)
      this.quantity--;
  }

}
