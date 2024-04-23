import { Component } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable } from 'rxjs';
import { IBasket } from '../../shared/Models/Basket';
import { AccountService } from '../../account/account.service';
import { IUser } from '../../shared/Models/User';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {

  basket$: Observable<IBasket | null>;
  currentUser$ : Observable<IUser | null>;

  constructor(private basketService :BasketService, private accountService : AccountService)
  {
    this.basket$= basketService.basket$;
    this.currentUser$ = accountService.currentUser;

  }

  logout()
  {
   this.accountService.logOut();
  }  

}
