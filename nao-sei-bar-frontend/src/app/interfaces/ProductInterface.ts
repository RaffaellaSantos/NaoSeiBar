export interface RegisterProduct {
  nome: string,
  tipo: string,
  valorVenda: number,
  quantidade: number,
  validade: string,
  marca: string
}

export interface Product extends RegisterProduct {
  id: number;
  valorCompra: number;
  lote: {
    id: number;
    dataFornecimento: string;
    descricao: string;
    valorTotal: number;
    fornecedor: string | null;
  };
  dataEntrada: string;
}

