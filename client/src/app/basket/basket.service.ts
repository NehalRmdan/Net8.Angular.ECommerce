import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket, IBasket, IBasketTotal } from '../shared/Models/Basket';
import { environment } from '../../environments/environment';
import { IBasketItem } from '../shared/Models/BasketItem';
import { IProduct } from '../shared/Models/IProduct';
import { BehaviorSubject, map } from 'rxjs';
import { IDeliveryMethod } from '../shared/Models/DeliveryMethod';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl= environment.apiUrl;
  basketUrl= this.baseUrl +'/api/basket'

  private basketSource = new BehaviorSubject<IBasket | null>(null);
  basket$ = this.basketSource.asObservable();

  private basketTotalSource = new BehaviorSubject<IBasketTotal | null>(null);
  basketTotal$ = this.basketTotalSource.asObservable();
  shipping=0;

  constructor(private http: HttpClient) { }
  
  
  getBasket(id : string )
  {
    let params= new HttpParams();
 
     params=  params.set('id',id);

   return  this.http.get<IBasket>(this.basketUrl,{ params : params})
    .pipe(
      map((basket :IBasket)=> { 
        this.basketSource.next(basket);
        this.calculateTotals();
      })
    );
  }

  setBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.basketUrl, basket).subscribe((response) => {
      this.basketSource.next(response);
      this.calculateTotals();
    })
  }
  deleteBasket(id : string)
  {
    let params= new HttpParams();
 
    params=  params.set('id',id);

    this.http.delete(this.basketUrl,{ params: params}).subscribe(
      { next : r => {
        localStorage.removeItem('basket_id');
        this.basketSource.next(null);
        this.basketTotalSource.next(null);
      },
      error : e=> { console.log(e);}
      }
    );

  }


  addItemToBasket(item: IProduct, quantity= 1)
  {
   const basketItem : IBasketItem = this.mapToBasketItem(item, quantity);
   const basket= this.getCurrentBasket() ?? this.createBasket();
   basket.items=this.addOrUpdateItem(basket.items, item, basketItem, quantity);
    this.setBasket(basket);
  }

  private addOrUpdateItem(basketItems: IBasketItem[], item: IProduct, basketItem: IBasketItem, quantity: number) {
    let currentItem = basketItems.findIndex(i => i.id == item.id);
    if (currentItem === -1) {
      basketItems.push(basketItem);
    }
    else {
      basketItems[currentItem].quantity += quantity;
    }
    return basketItems;
  }

  createBasket(): IBasket {
    const basket= new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  mapToBasketItem(item: IProduct, quantity: number): IBasketItem {
 return  {
      id: item.id,
      price : item.price,
      productName : item.name,
      pictureUrl : item.pictureUrl,
      brand : item.productBrandName,
      type : item.productTypeName,
      quantity: quantity
   }
  }

  getCurrentBasket()
  {
    return this.basketSource.value;
  }

  incrementItemQuantity(item:IBasketItem)
  {
    const basket= this.getCurrentBasket() ?? this.createBasket();
    let basketItemIndex= basket.items.findIndex(x=> x.id === item.id);
    if(basketItemIndex != -1)
    {
          basket.items[basketItemIndex].quantity++;
          this.setBasket(basket);
    }    
  }

  decrementItemQuantity(item:IBasketItem)
  {
    const basket= this.getCurrentBasket() ?? this.createBasket();
    let basketItemIndex= basket.items.findIndex(x=> x.id === item.id);
    if(basketItemIndex != -1)
    {
       if( basket.items[basketItemIndex].quantity >1)
       {
          basket.items[basketItemIndex].quantity--;
          this.setBasket(basket);
       }
       else
       {
          this.removeItemFromBasket(item);        
       }
    }    
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket= this.getCurrentBasket() ?? this.createBasket();
    let foundItem= basket.items.some(x=> x.id === item.id);
    if(foundItem )
    {
      basket.items= basket.items.filter(x=> x.id !== item.id);
      if(basket.items.length == 0)
      {
        this.deleteBasket(basket.id);
      }
      else
      {
        this.setBasket(basket);
      }
    }
  }

  calculateTotals()
  {
    const basket= this.getCurrentBasket() ?? this.createBasket();
    const shipping = this.shipping;
    const subtotal= basket.items.reduce((a,b) => b.price * b.quantity + a,0);
    const total = shipping + subtotal;
    this.basketTotalSource.next({shipping,total,subtotal});
  }

  // setShippingPrice(deliveryMethod: IDeliveryMethod) {
  //   this.shipping = deliveryMethod.price;
  //   const basket = this.getCurrentBasket();
  //   basket.deliveryMethodId = deliveryMethod.id;
  //   basket.shippingPrice = deliveryMethod.price;
  //   this.calculateTotals();
  //   this.setBasket(basket);
  // }
}
