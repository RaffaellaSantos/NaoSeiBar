'use client'

import Image from "next/image";
import Logo from "../../public/logo.svg";
import { useRouter } from "next/navigation";

export default function Login() {
  const router = useRouter();
  return (
    <div className="flex h-[100vh]">
      <div className="bg-[#382C30] w-1/3 flex justify-center">
        <Image src={Logo} alt={"Logo"}></Image>
      </div>
      <div className="flex flex-col items-center justify-center w-2/3">
        <h1 className="text-6xl p-24">LOGIN</h1>
        <input placeholder="CPF" className="m-6"></input>
        <input placeholder="Senha" type="password" className="m-6"></input>
        <button onClick={() => router.push("/atendente")}>Entrar</button>
      </div>
    </div>
  );
}
