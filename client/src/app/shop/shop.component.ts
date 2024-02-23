import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/Models/IProduct';
import { IBrand } from '../shared/Models/Brand';
import { IProductType } from '../shared/Models/ProductType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  
  products : IProduct[] =[];
  brands : IBrand[]= [];
  types : IProductType[]= [];
  selectedBrnadId=0;
  selectedTypeId=0;
  
  constructor(private shopService: ShopService)
  {

  }
  ngOnInit(): void {

    this.getProducts();

    this.getBrands();

    this.getProductTypes();
  }


  private getProductTypes() {
    this.shopService.getProductTypes().subscribe({
      next: response => { this.types = [{"id":0,"name":"All"},...response] ; },
      error: (e) => { console.log(e); }
    });
  }

  private getBrands() {
    this.shopService.getBrands().subscribe({
      next: response => { this.brands = [{"id":0,"name":"All"},...response]; },
      error: (e) => { console.log(e); }
    });
  }

  private getProducts() {
    this.shopService.getProducts(this.selectedBrnadId, this.selectedTypeId).subscribe({
      next: response => { this.products = response?.data ?? []; },
      error: (e) => { console.log(e); }
    });
  }

  onSelectBranad(id : number){
    debugger;
    this.selectedBrnadId= id;
    this.getProducts();
  }

  onSelectType(id : number){
    debugger;
    this.selectedTypeId= id;
    this.getProducts();
  }

}
