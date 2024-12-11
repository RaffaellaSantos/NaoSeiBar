import GenericTable from "../components/genericTable";
import Navbar from "../components/navbar";

export default function Atendente() {
  interface User {
    id: number;
    nome: string;
    email: string;
  }

  const users: User[] = [
    { id: 1, nome: "Alice", email: "alice@example.com" },
    { id: 2, nome: "Bob", email: "bob@example.com" },
    { id: 3, nome: "Charlie", email: "charlie@example.com" },
  ];

  const columns = [
    { header: "Cliente", accessor: "nome" },
    { header: "Status", accessor: "status" },
    { header: "", accessor: "" },
  ];
  return (
    <>
      <Navbar />
      <main className="p-20">
        <h1>Clientes Ativos</h1>
        <section className="bg-[#FBFBE2]">
          <div className="flex">
            <div className="flex"></div>
            <div className="flex"></div>
            <div className="flex"></div>
            <button>Cadastrar Cliente</button>
          </div>
          <GenericTable columns={columns} data={users} />
        </section>
      </main>
    </>
  );
}
