import { Component } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasketTotal } from '../Models/Basket';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrl: './order-totals.component.scss'
})
export class OrderTotalsComponent {
  basketTotals$: Observable<IBasketTotal | null>;
  constructor(private basketService : BasketService)
  {
    this.basketTotals$= basketService.basketTotal$;
  }


}
