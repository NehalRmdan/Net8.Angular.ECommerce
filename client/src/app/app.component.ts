import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';
import { IUser } from './shared/Models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
constructor(private basketService: BasketService, private accountService : AccountService)
{
  
}

  ngOnInit() {
    this.getCurrentUser();
    this.getBasket();
  }

  private getBasket() {
    let currentBasketId = localStorage.getItem('basket_id');
    if (currentBasketId) {
      this.basketService.getBasket(currentBasketId).subscribe(x => console.log('Initialized basket'));
    }
  }

  private getCurrentUser() {
    let token  = localStorage.getItem('token');
     this.accountService.loadCurrentUser(token).subscribe(user => {
      if (user) {
        console.log('User loaded', user);
      } else {
        console.log('No user found');
      }
    });
  }
}
