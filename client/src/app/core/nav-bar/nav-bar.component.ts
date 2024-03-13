import { Component } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../../shared/Models/Basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {

  basket$: Observable<IBasket | null>;

  constructor(private basketService :BasketService)
  {
    this.basket$= basketService.basket$;
  }

}
