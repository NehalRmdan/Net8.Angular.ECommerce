import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from '../shared/Models/IProducts';
import { Observable, map } from 'rxjs';
import { IBrand } from '../shared/Models/Brand';
import { IProductType } from '../shared/Models/ProductType';
import { ShopParams } from '../shared/Models/ShopParams';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: any="https://localhost:7105/api/";
  constructor(private http : HttpClient) { }

  getProducts (shopParams: ShopParams) : Observable<IProducts|null>
  {
    let params= new HttpParams();
    if(shopParams.brandId)
    {
      params= params.append("brandId",shopParams.brandId.toString());
    }
    
    if(shopParams.typeId)
    {
      params= params.append("typeId",shopParams.typeId.toString());
    }

    if(shopParams && shopParams.search !='')
    {
    params= params.append("search",shopParams.search);
    }

    params= params.append("sort",shopParams.sortOption);
    
    params= params.append("pageSize",shopParams.pageSize);

    params= params.append("pageIndex",shopParams.pageNumber);

    let productsUrl= this.baseUrl+"products"
    return this.http
    .get<IProducts>(productsUrl,{observe: 'response', params})
    .pipe( map( response => {return response?.body}));
  }

  getBrands () : Observable<IBrand[]>
  {
    let productsUrl= this.baseUrl+"products/brands"
    return this.http.get<IBrand[]>(productsUrl);
  }

  getProductTypes () : Observable<IProductType[]>
  {
    let productsUrl= this.baseUrl+"products/types"
    return this.http.get<IProductType[]>(productsUrl);
  }

}
