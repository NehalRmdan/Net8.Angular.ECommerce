import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NotFoundComponent } from './components/not-found/not-found.component';




@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    NotFoundComponent
  ],
  imports: [
    CommonModule,
    PaginationModule
  ],
  exports:[
    PagingHeaderComponent,
    PagerComponent,
    NotFoundComponent
  ]
})
export class SharedModule { }
