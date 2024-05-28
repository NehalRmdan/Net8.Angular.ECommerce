import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './text-input/text-input.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent
  ],
  imports: [
    CommonModule,
    PaginationModule,
    FormsModule,
    ReactiveFormsModule,
    CdkStepperModule,
    BsDropdownModule.forRoot()
  ],
  exports:[
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    BsDropdownModule,
    TextInputComponent,
    StepperComponent,
    CdkStepperModule
  ]
})
export class SharedModule { }
