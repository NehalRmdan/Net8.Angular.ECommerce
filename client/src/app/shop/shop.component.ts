import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/Models/IProduct';
import { IBrand } from '../shared/Models/Brand';
import { IProductType } from '../shared/Models/ProductType';
import { ShopParams } from '../shared/Models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {
  
  products : IProduct[] =[];
  totalCount: number=0;
  brands : IBrand[]= [];
  types : IProductType[]= [];
  shopParams = new ShopParams();
  
  sortOptions=[{name:'name', value:'name'},
{name:'Price: Low to High', value: 'priceAsc'},
{name:'Price: High to Low', value: 'priceDesc'},
]
@ViewChild('search') searchElement!: ElementRef;

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
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => { this.products = response?.data ?? [];
      this.totalCount= response?.count ?? 0;
      },
      error: (e) => { console.log(e); }
    });
  }

  onSelectBranad(id : number){
    this.shopParams.brandId= id;
    this.shopParams.pageNumber= 1;
    this.getProducts();
  }

  onSelectType(id : number){
    this.shopParams.typeId= id;
    this.shopParams.pageNumber= 1;
    this.getProducts();
  }
  onSelectdSortOptions(event : any)
  {
    this.shopParams.sortOption= event.value;
    this.shopParams.pageNumber= 1;
    this.getProducts();
  }

  onPageChanged(page: any)
  {
    this.shopParams.pageNumber= page;

    this.getProducts();
  }

  onSearchClicked()
  {
    this.shopParams.search=this.searchElement.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onResetClicked()
  {
    this.shopParams= new ShopParams();
    this.searchElement.nativeElement.value='';
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
}
