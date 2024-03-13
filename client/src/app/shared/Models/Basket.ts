import { v4 as uuidv4 } from 'uuid';
import { IBasketItem } from "./BasketItem"

export interface IBasket  {
    id: string;
    items: IBasketItem[];
  }
  
  export interface IBasketTotal  {
    total: number;
    shipping: number;
    subtotal: number;
  }

  export class Basket implements IBasket {
    constructor()
    {}
      id: string = uuidv4();
      items: IBasketItem[]=[];
  }
 
  