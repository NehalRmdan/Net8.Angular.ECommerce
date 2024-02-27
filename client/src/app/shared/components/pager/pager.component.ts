import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.scss'
})
export class PagerComponent {
    @Input() totalCount: number=0;
    @Input() pageSize: number=6;
    @Output() pageChanges = new EventEmitter<number>();

    onPagerChange(event: any)
    {
      this.pageChanges.emit(event.page);
    }

}
