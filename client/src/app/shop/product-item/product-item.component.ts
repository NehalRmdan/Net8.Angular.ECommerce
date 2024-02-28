import { Component, Input } from '@angular/core';
import { IProduct } from '../../shared/Models/IProduct';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
export class ProductItemComponent {
@Input() product :IProduct | undefined;

constructor(private _router: Router)
{}
onView(product : IProduct | undefined)
{
 debugger;
 let id= product?.id;
 this._router.navigate(['/shop',id]);
}
}
