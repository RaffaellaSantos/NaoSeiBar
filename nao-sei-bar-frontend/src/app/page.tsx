"use client";

import Image from "next/image";
import Logo from "../../public/logo.svg";
import { useRouter } from "next/navigation";
import { useState } from "react";
import axios from "axios";
import { API_URL } from "./constants/Constants";
import { url } from "inspector";

export default function Login() {
  const [cpf, setCpf] = useState("");
  const [senha, setSenha] = useState("");
  const router = useRouter();
  const urlteste = "http://swapi.dev/api/films/1/";
  const handleTest = async () => {
    const response = await axios.get(urlteste);
    console.log(response);
  };
  const handleLogin = async () => {
    const response = await axios.post(`${API_URL}/api/Login/login`, {
      Cpf: cpf,
      Senha: senha,
    });
    if (response) {
      router.push("/produtos");
    } else {
      throw new Error("falha no login" + response);
    }
  };
  return (
    <div className="flex h-[100vh]">
      <div className="bg-[#382C30] w-1/3 flex justify-center">
        <Image src={Logo} alt={"Logo"}></Image>
      </div>
      <div className="flex flex-col items-center justify-center w-2/3">
        <h1 className="text-6xl p-24">LOGIN</h1>
        <input
          placeholder="CPF"
          className="m-6"
          onChange={(e) => setCpf(e.target.value)}
        ></input>
        <input
          placeholder="Senha"
          type="password"
          className="m-6"
          onChange={(e) => setSenha(e.target.value)}
        ></input>
        <button onClick={handleLogin}>Entrar</button>
      </div>
    </div>
  );
}
