import axios from "axios";
import { TipoBebida } from "../enums/TipoBebida";
import { API_URL_GESTOR } from "../constants/Constants";

export const getProducts = async () => {
  try {
    const response = await axios.get(`${API_URL_GESTOR}/ListarProdutos`, {
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
      },
    });
    return response.data;
  } catch (err) {
    console.log(err);
  }
};
