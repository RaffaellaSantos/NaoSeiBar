"use client";

import { Rows3 } from "lucide";
import GenericTable, { Column } from "../components/genericTable";
import Navbar from "../components/navbar";
import { useEffect, useState } from "react";
import RegisterProductPopup from "../components/popups/RegisterProductPopup";
import { Product } from "../interfaces/ProductInterface";
import { getProducts } from "../services/GetProduct";

export default function ProductPage() {
  const [isOpen, setIsOpen] = useState(false);
  const [products, setProducts] = useState<any[]>([
    {
      id: 1,
      nome: "Coca-Cola",
      tipo: "NaoAlcoolico",
      valorCompra: 0,
      valorVenda: 10,
      marca: "Coca-Cola",
      quantidade: 30,
      validade: "2024-12-08T03:44:12.594",
      lote: {
        id: 1,
        dataFornecimento: "2024-12-07T23:30:47.815692",
        descricao: "Lote Mockado",
        valorTotal: 100,
        fornecedor: "Fornecedor XYZ",
      },
      dataEntrada: "2024-12-07T23:30:47.816937",
    },
    {
      id: 2,
      nome: "Pepsi",
      tipo: "NaoAlcoolico",
      valorCompra: 0,
      valorVenda: 12,
      marca: "PepsiCo",
      quantidade: 45,
      validade: "2025-01-15T12:30:00.000",
      lote: {
        id: 2,
        dataFornecimento: "2024-12-01T10:15:00.000",
        descricao: "Lote Especial",
        valorTotal: 180,
        fornecedor: "Fornecedor ABC",
      },
      dataEntrada: "2024-12-01T10:30:00.000",
    },
    {
      id: 3,
      nome: "Fanta Laranja",
      tipo: "NaoAlcoolico",
      valorCompra: 0,
      valorVenda: 8,
      marca: "Coca-Cola",
      quantidade: 25,
      validade: "2025-03-25T03:44:12.594",
      lote: {
        id: 3,
        dataFornecimento: "2024-11-15T14:10:00.000",
        descricao: "Lote Promocional",
        valorTotal: 200,
        fornecedor: "Fornecedor DEF",
      },
      dataEntrada: "2024-11-15T14:10:00.000",
    },
    {
      id: 4,
      nome: "Guaraná Antarctica",
      tipo: "NaoAlcoolico",
      valorCompra: 0,
      valorVenda: 9,
      marca: "Ambev",
      quantidade: 50,
      validade: "2025-02-20T08:00:00.000",
      lote: {
        id: 4,
        dataFornecimento: "2024-11-20T11:20:00.000",
        descricao: "Lote Regular",
        valorTotal: 250,
        fornecedor: "Fornecedor GHI",
      },
      dataEntrada: "2024-11-20T11:20:00.000",
    },
    {
      id: 5,
      nome: "Sprite",
      tipo: "NaoAlcoolico",
      valorCompra: 0,
      valorVenda: 11,
      marca: "Coca-Cola",
      quantidade: 40,
      validade: "2025-04-10T06:00:00.000",
      lote: {
        id: 5,
        dataFornecimento: "2024-12-10T09:00:00.000",
        descricao: "Lote de Inverno",
        valorTotal: 220,
        fornecedor: "Fornecedor JKL",
      },
      dataEntrada: "2024-12-10T09:00:00.000",
    },
  ]);
  const columns: Column[] = [
    { id: "id", label: "ID", align: "left" },
    { id: "nome", label: "Nome", align: "right" },
    { id: "tipo", label: "Tipo", align: "right" },
    { id: "quantidade", label: "Quantidade", align: "right" },
  ];

  useEffect(() => {
    const fecthProducts = async () => {
      const products = await getProducts()
      setProducts(products)
      console.log(products)
    }
    fecthProducts();
  }, [products]) 

  const rows = products;
  const handleRegisterButton = () => {
    setIsOpen(!isOpen);
  };

  // Import the functions you need from the SDKs you need

  // TODO: Add SDKs for Firebase products that you want to use
  // https://firebase.google.com/docs/web/setup#available-libraries

  // Your web app's Firebase configuration
  // For Firebase JS SDK v7.20.0 and later, measurementId is optional
  const firebaseConfig = {
    apiKey: "AIzaSyApZJsy9egUaQ8FkKT-cC6W7p81FzU3cFs",
    authDomain: "nao-sei-bar.firebaseapp.com",
    projectId: "nao-sei-bar",
    storageBucket: "nao-sei-bar.firebasestorage.app",
    messagingSenderId: "963043144738",
    appId: "1:963043144738:web:1d1ed7f25402e1e92b067b",
    measurementId: "G-XLJ4Q7TQRX",
  };

  // Initialize Firebase

  return (
    <>
      <Navbar />
      <div className="px-24">
        <h1 className="py-7">Produtos</h1>
        <div>
          <GenericTable
            columns={columns}
            rows={rows}
            onClick={handleRegisterButton}
          />
        </div>
      </div>
      {isOpen && <RegisterProductPopup />}
    </>
  );
}
