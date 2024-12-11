import { Product, RegisterProduct } from "@/app/interfaces/ProductInterface";
import { registerProduct } from "@/app/services/RegisterProduct";
import { ChangeEvent, useState, useEffect } from "react";

export default function RegisterProductPopup() {
  const [product, setProduct] = useState<RegisterProduct>({
    nome: '',
    validade: '',
    valorVenda: 0,
    marca: '',
    quantidade: 0,
    tipo: 'NaoAlcoolico'
  });

  const [isOpen, setIsOpen] = useState(true); // Controla se o popup está aberto ou fechado

  const handleChangeInput = (event: ChangeEvent<HTMLInputElement | HTMLSelectElement>): void => {
    const { name, value } = event.target;
    
    // Verificação de tipo para campos numéricos
    if (name === 'quantidade' || name === 'valorVenda') {
      setProduct((prevData) => ({
        ...prevData,
        [name]: value ? parseFloat(value) : 0, // Converte para número ou 0 se vazio
      }));
    } else {
      setProduct((prevData) => ({
        ...prevData,
        [name]: value || "", // Para texto, mantém o valor
      }));
    }
  };

  const handleClickOutside = (event: React.MouseEvent) => {
    // Verifica se o clique foi fora do modal
    const modal = event.target as HTMLElement;
    if (modal && modal.classList.contains('modal-background')) {
      setIsOpen(false); // Fecha o popup
    }
  };

  useEffect(() => {
    console.log("Produto Atualizado:", product);
  }, [product]); // Este efeito será chamado sempre que o produto for alterado.

  if (!isOpen) return null; // Se o popup estiver fechado, não renderiza nada

  const handleRegisterProduct = async () => {
    try {
      const response = await registerProduct(product)
      console.log('foi')
    } catch (err) {
      console.log(err)
    }
    
  }

  return (
    <div
      className="fixed inset-0 bg-black bg-opacity-30 flex items-center justify-center z-50 modal-background"
      onClick={handleClickOutside} // Fecha ao clicar fora do modal
    >
      <div className="bg-[#FBFBE2] rounded-lg shadow-lg w-[400px] h-3/5 p-6 relative flex flex-col" onClick={(e) => e.stopPropagation()}>
        {/* Previne que o clique dentro do modal feche ele */}
        <h1 className="py-5 text-2xl">Cadastrar produto</h1>
        
        <p>Nome</p>
        <input type="text" name="nome" onChange={handleChangeInput} value={product.nome} className="mb-4 p-2 rounded" />

        <p>Tipo</p>
        <select
          name="tipo"
          value={product.tipo}
          onChange={handleChangeInput}
          className="mb-4 p-2 rounded"
        >
          <option value="Cerveja">Cerveja</option>
          <option value="Cachaca">Cachaça</option>
          <option value="Vinho">Vinho</option>
          <option value="Vodka">Vodka</option>
          <option value="Gin">Gin</option>
          <option value="Rum">Rum</option>
          <option value="Whisky">Whisky</option>
          <option value="NaoAlcoolico">NaoAlcoolico</option>
        </select>

        <p>Valor</p>
        <input
          type="number"
          name="valorVenda"
          onChange={handleChangeInput}
          value={product.valorVenda}
          className="mb-4 p-2 rounded"
        />

        <p>Marca</p>
        <input type="text" name="marca" onChange={handleChangeInput} value={product.marca} className="mb-4 p-2 rounded" />

        <p>Quantidade</p>
        <input
          type="number"
          name="quantidade"
          onChange={handleChangeInput}
          value={product.quantidade}
          className="mb-4 p-2 rounded"
        />

        <p>Data de Validade</p>
        <input
          type="date"
          name="validade"
          onChange={handleChangeInput}
          value={product.validade}
          className="mb-4 p-2 rounded"
        />

        <button
          className="bg-foreground text-background rounded-xl p-2 mt-4"
          onClick={handleRegisterProduct}
        >
          Cadastrar produto
        </button>
      </div>
    </div>
  );
}
