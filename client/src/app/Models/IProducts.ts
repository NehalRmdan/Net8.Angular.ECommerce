import { IProduct } from "./IProduct"

export interface IProducts {
    pageIndex?: number
    pageSize?: number
    count?: number
    data?: IProduct[]
  }