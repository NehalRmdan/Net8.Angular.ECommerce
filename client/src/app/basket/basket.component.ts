import { Component } from '@angular/core';
import { BasketService } from './basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../shared/Models/Basket';
import { IBasketItem } from '../shared/Models/BasketItem';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.scss'
})
export class BasketComponent {
  basket$ : Observable<IBasket | null>;
  constructor(private basketService : BasketService)
  {
    this.basket$= basketService.basket$;
  }

  removeBasketItem(item : IBasketItem)
  {
    this.basketService.removeItemFromBasket(item);

  }

  incrementItem(item:IBasketItem)
  {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItem(item: IBasketItem)
  {
    this.basketService.decrementItemQuantity(item);
  }
}
