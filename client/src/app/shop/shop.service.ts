import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from '../shared/Models/IProducts';
import { Observable, map } from 'rxjs';
import { IBrand } from '../shared/Models/Brand';
import { IProductType } from '../shared/Models/ProductType';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: any="https://localhost:7105/api/";
  constructor(private http : HttpClient) { }

  getProducts (brandId?: number, typeId? : number) : Observable<IProducts|null>
  {
    let params= new HttpParams();
    if(brandId)
    {
      params= params.append("brandId",brandId.toString());
    }
    
    if(typeId)
    {
      params= params.append("typeId",typeId.toString());
    }

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
