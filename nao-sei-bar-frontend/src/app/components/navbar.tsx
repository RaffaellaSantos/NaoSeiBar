"use client";

import Image from "next/image";
import Martini from "../../../public/Martini.svg";
import ExitButton from "../../../public/Botão Sair.svg";
import Profile from "../../../public/User.svg";
import { useRouter } from "next/navigation";

export default function Navbar() {
  const router = useRouter();
  return (
    <nav className="flex justify-between w-full bg-[#382C30] p-6">
      <Image src={Martini} alt="Martini" />
      <div className="flex gap-5">
        <button
          onClick={() => {
            router.replace("/");
          }}
        >
          <Image src={ExitButton} alt="Sair" />
        </button>

        <Image src={Profile} alt="Perfil" />
      </div>
    </nav>
  );
}
