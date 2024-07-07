import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IBasket } from '../../shared/Models/Basket';
import { BasketService } from '../../basket/basket.service';
import { CheckoutService } from '../checkout.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrl: './checkout-payment.component.scss'
})
export class CheckoutPaymentComponent {
  @Input() checkoutForm!: FormGroup;
  stripe: any;
  
  loading = false;
  
  constructor(private basketService: BasketService, private checkoutService: CheckoutService,
    private toastr: ToastrService, private router: Router) { }
  async submitOrder() {
    this.loading = true;
    const basket = this.basketService.getCurrentBasket();
    try {
      if(basket)
        {
      const createdOrder = await this.createOrder(basket);
        }
      this.loading = false;
    } catch (error) {
      console.log(error);
      this.loading = false;
    }
  }

  private async createOrder(basket: IBasket) {
    const orderToCreate = this.getOrderToCreate(basket);
    return this.checkoutService.createOrder(orderToCreate).toPromise();
  }


  private getOrderToCreate(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm.get('deliveryForm')?.get('deliveryMethod')?.value,
      shipToAddress: this.checkoutForm.get('addressForm')?.value
    };
  }
}
