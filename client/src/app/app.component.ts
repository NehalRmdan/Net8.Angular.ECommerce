import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProducts } from './Models/IProducts';
import { IProduct } from './Models/IProduct';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Toy Shop';
  products: IProduct[]= [];

  constructor(private httpclient:HttpClient)
  {}

  ngOnInit(): void {
    let x : IProducts;
    let productsApi="https://localhost:7105/api/products";
    this.httpclient.get(productsApi).subscribe( 
      response => this.onSuccess(response), error => {
      
    })
  }
  
  onSuccess(r : any)
  {
    console.log(r)

    let pagination= r;
    this.products = r.response;
    
  }
}
