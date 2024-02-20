import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/Models/IProduct';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  
  products : IProduct[]= [];
  
  constructor(private shopService: ShopService)
  {

  }
  ngOnInit(): void {

    this.shopService.getProducts().subscribe({
     next: response =>{ this.products= response.data ?? []},
     error: (e) => { console.log(e)}
    });

    this.shopService.getProducts().subscribe(
      response =>{ this.products= response.data ?? []}
      , error =>{console.log(error);}
      );
  }

}
