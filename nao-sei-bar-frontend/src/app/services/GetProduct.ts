import axios from "axios";
import { TipoBebida } from "../enums/TipoBebida";
import { API_URL_GESTOR } from "../constants/Constants";

export const getProducts = async () => {
    try {
        const response = await axios.get(`${API_URL_GESTOR}/ListarProdutos`
        );
        return response.data;
    } catch (err) {
        console.log(err)
    }
}