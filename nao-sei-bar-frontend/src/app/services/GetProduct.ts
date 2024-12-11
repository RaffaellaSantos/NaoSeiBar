import axios from "axios";
import { API_URL_GESTOR } from "../constants/Constants";
import { Product } from "../interfaces/ProductInterface";

export const getProducts = async () => {
  try {
    const response = await axios.get(`${API_URL_GESTOR}/ListarProdutos`, {
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
      },
    });
    return response.data.items as Product[];
  } catch (err) {
    console.log(err);
  }
};
