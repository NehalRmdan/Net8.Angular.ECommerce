import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CheckoutRoutingModule } from './checkout-routing.module';
import { CheckoutComponent } from './checkout.component';
import { SharedModule } from '../shared/shared.module';
import { CheckoutAddressComponent } from './checkout-address/checkout-address.component';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';
import { CheckoutSuccessComponent } from './checkout-success/checkout-success.component';
import { CheckoutDeliveryComponent } from './checkout-delivery/checkout-delivery.component';
import { CheckoutReviewComponent } from './checkout-review/checkout-review.component';


@NgModule({
  declarations: [
    CheckoutComponent,
    CheckoutAddressComponent,
    CheckoutPaymentComponent,
    CheckoutSuccessComponent,
    CheckoutDeliveryComponent,
    CheckoutReviewComponent
  ],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    SharedModule
  ]
})
export class CheckoutModule { }
