"use client"

import { Rows3 } from "lucide";
import GenericTable, { Column } from "../components/genericTable";
import Navbar from "../components/navbar";
import { useState } from "react";
import RegisterProductPopup from "../components/popups/RegisterProductPopup";

export default function ProductPage() {
    const [isOpen, setIsOpen] = useState(false)
  const columns: Column[] = [
    { id: "id", label: "ID", align: "left" },
    { id: "name", label: "Nome", align: "right" },
    { id: "type", label: "Tipo", align: "right" },
    { id: "quantity", label: "Quantidade", align: "right" },
  ];

  const rows = [
    {
      id: "0001",
      name: "Bohemia 1L",
      type: "Cerveja",
      quantity: 23,
      history: [
        { date: "2020-01-05", customerId: "11091700", amount: 3 },
        { date: "2020-01-02", customerId: "Anonymous", amount: 1 },
      ],
    },
    {
      id: "0002",
      name: "Antártica 1L",
      type: "Cerveja",
      quantity: 24,
      history: [{ date: "2020-01-06", customerId: "12345678", amount: 2 }],
    },
    {
      id: "0002",
      name: "Antártica 1L",
      type: "Cerveja",
      quantity: 24,
      history: [{ date: "2020-01-06", customerId: "12345678", amount: 2 }],
    },
    {
      id: "0002",
      name: "Antártica 1L",
      type: "Cerveja",
      quantity: 24,
      history: [{ date: "2020-01-06", customerId: "12345678", amount: 2 }],
    },
    {
      id: "0002",
      name: "Antártica 1L",
      type: "Cerveja",
      quantity: 24,
      history: [{ date: "2020-01-06", customerId: "12345678", amount: 2 }],
    },
    {
      id: "0002",
      name: "Antártica 1L",
      type: "Cerveja",
      quantity: 24,
      history: [{ date: "2020-01-06", customerId: "12345678", amount: 2 }],
    },
  ];
  const handleRegisterButton = () => {
    setIsOpen(!isOpen)
  }

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
