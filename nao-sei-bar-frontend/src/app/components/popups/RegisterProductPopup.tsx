import { Product } from "@/app/interfaces/ProductInterface";
import { ChangeEvent, useState } from "react";

export default function RegisterProductPopup() {
  const [product, setProduct] = useState<Product>({});
  const handleChangeInput = (event: ChangeEvent<HTMLInputElement>): void => {
    const { name, value } = event.target;
    setProduct((prevData) => ({
      ...prevData,
      [name]: value || "",
    }));
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-30 flex items-center justify-center z-50">
      <div className="bg-[#FBFBE2] rounded-lg shadow-lg w-[400px] h-3/5 p-6 relative flex flex-col">
        <h1 className="py-5 text-2xl">Cadastrar produto</h1>
        <p>Nome</p>
        <input type="text" onChange={handleChangeInput} />
        <p>Tipo</p>
        <input type="text" onChange={handleChangeInput} />
        <p>Valor</p>
        <input type="text" onChange={handleChangeInput} />
        <p>Marca</p>
        <input type="text" onChange={handleChangeInput} />
        <p>Quantidade</p>
        <input type="text" onChange={handleChangeInput} />
        <p>Data de Validade</p>
        <input type="date" onChange={handleChangeInput} />
        <button className="bg-foreground text-background rounded-xl">
          Cadastrar produto
        </button>
      </div>
    </div>
  );
}
