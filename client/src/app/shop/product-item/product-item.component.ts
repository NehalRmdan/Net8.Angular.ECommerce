import { Component, Input } from '@angular/core';
import { IProduct } from '../../shared/Models/IProduct';
import { Router } from '@angular/router';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
export class ProductItemComponent {
@Input() product! :IProduct;

constructor(private _router: Router, private basketService : BasketService)
{}

onView(product : IProduct)
{
 let id= product?.id;
 this._router.navigate(['/shop',id]);
}

AddItemToBasket()
{
  this.basketService.addItemToBasket(this.product);
}

}