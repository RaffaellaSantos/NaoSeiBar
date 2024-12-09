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
  const [products, setProducts] = useState<Product[]>([])
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

  const rows = products
  const handleRegisterButton = () => {
    setIsOpen(!isOpen);
  };

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
