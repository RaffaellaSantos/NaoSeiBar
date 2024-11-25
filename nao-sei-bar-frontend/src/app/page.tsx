import Image from "next/image";
import Logo from "../../public/logo.svg"

export default function Login() {
  return (
    <div className="flex">
      <div className="bg-[#382C30] h-max">
        <Image src={Logo} alt={"Logo"}></Image>
      </div>
      <div></div>
    </div>
  );
}
