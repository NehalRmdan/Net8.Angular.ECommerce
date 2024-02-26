import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrl: './paging-header.component.scss'
})
export class PagingHeaderComponent {
@Input() totalCount: number=0;
@Input() pageNumber: number=1;
@Input() pageSize: number=6;



}
