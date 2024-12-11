import axios from "axios";
import { API_URL_GESTOR } from "../constants/Constants";
import { Product, RegisterProduct } from "../interfaces/ProductInterface";
import { log } from "console";

export const registerProduct = async (product: RegisterProduct) => {
  try {
    const response = await axios.post(
      `${API_URL_GESTOR}/CadastrarProduto`,
      product, {
        headers: {
          "Content-Type": 'multipart/form-data'
        }
      }
    );
    return response;
  } catch (error) {
    console.log(error);
  }
};
