import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent implements OnInit{

  checkoutForm! : FormGroup;
  constructor(private fb : FormBuilder,private accountService : AccountService)
    {
    }

  ngOnInit(): void {
      this.createCheckoutForm();
  }

    createCheckoutForm()
    {
      this.checkoutForm = this.fb.group({
        addressForm: this.fb.group({
          firstName: [null, Validators.required],
          lastName: [null, Validators.required],
          street: [null, Validators.required],
          city: [null, Validators.required],
          state: [null, Validators.required],
          zipCode: [null, Validators.required],
          building: [null, Validators.required],
          apartment: [null, Validators.required],
          mark: [null, Validators.required],


        }),
        deliveryForm: this.fb.group({
          deliveryMethod: [null, Validators.required]
        }),
        paymentForm: this.fb.group({
          nameOnCard: [null, Validators.required]
        })
      });
    }
  
    get addressForm(): FormGroup {
      return this.checkoutForm.get('addressForm') as FormGroup;
    }
}
