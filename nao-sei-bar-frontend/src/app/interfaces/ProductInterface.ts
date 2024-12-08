export interface Product {
  id: string;
  name: string;
  type: string;
  quantity: number;
}

export interface DetailedProduct extends Product {
  batch: string;
  price: number;
  supplier: string;
  brand: string;
  expiration: string;
  entry: string;
}
