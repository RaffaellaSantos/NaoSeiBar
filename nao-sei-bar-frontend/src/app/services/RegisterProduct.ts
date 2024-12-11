import axios from "axios";
import { API_URL_GESTOR } from "../constants/Constants";
import { Product } from "../interfaces/ProductInterface";
import { log } from "console";

export const registerProduct = async (product: Product) => {
  try {
    const response = await axios.post(
      `${API_URL_GESTOR}/CadastrarProduto`,
      product
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};
