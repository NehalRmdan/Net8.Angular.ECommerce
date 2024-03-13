import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
constructor(private basketService: BasketService)
{
  
}

  ngOnInit() {
    let currentBasketId= localStorage.getItem('basket_id');
    if(currentBasketId)
    {
      this.basketService.getBasket(currentBasketId).subscribe(x=> console.log('Initialized basket'));
    }
  }
}
