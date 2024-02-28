import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shop.service';
import { IProduct } from '../../shared/Models/IProduct';

@Component({
  selector: 'app-product-item-detail',
  templateUrl: './product-item-detail.component.html',
  styleUrl: './product-item-detail.component.scss'
})
export class ProductItemDetailComponent implements OnInit {

  product: IProduct| undefined;

  constructor(private _shopService : ShopService,private _route: ActivatedRoute)
  {

  }

  ngOnInit(): void {

    let id=+(this._route.snapshot.paramMap.get('id')?? 0);
  
    this._shopService.getProduct(id).subscribe({
      next: response => { this.product = response; },
      error: err => { console.log(" error in product item.")}
    })
  }

}
