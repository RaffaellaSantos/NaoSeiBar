export interface Product {
  id?: string;
  nome: string;
  tipo: string;
  quantidade: number;
  valorVenda: number
  marca: string;
  validade: string;
}

export interface DetailedProduct extends Product {
  batch: string;
  supplier: string;
  entry: string;
}
