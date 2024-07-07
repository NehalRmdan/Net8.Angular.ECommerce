import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../account/account.service';
import { ToastrService } from 'ngx-toastr';
import { IAddress } from '../../shared/Models/Address';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrl: './checkout-address.component.scss'
})
export class CheckoutAddressComponent implements OnInit{
  @Input() checkoutForm!: FormGroup;

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }

  
  saveUserAddress() {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm')?.value).subscribe(
    {
      next : (r:IAddress) =>{
      this.toastr.success('Address saved');
      this.checkoutForm.get('addressForm')?.reset(r);
      },
      error: e=> {
      this.toastr.error(e.message);
      console.log(e);

      }
    })
  }

  get f(): { [key: string]: AbstractControl } {
    //const addressFormGroup = this.checkoutForm.get('addressForm') as FormGroup;
    debugger;
    var c= this.checkoutForm;
    return  this.checkoutForm.controls;
  }

  get addressForm(): FormGroup {
    return this.checkoutForm.get('addressForm') as FormGroup;
  }

}
