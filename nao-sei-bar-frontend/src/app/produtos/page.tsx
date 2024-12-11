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
  }, []) 

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
