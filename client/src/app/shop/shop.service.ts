import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from '../shared/Models/IProducts';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: any="https://localhost:7105/api/";
  constructor(private http : HttpClient) { }

  getProducts () : Observable<IProducts>
  {
    let productsUrl= this.baseUrl+"products"
    return this.http.get<IProducts>(productsUrl);
  }
}
