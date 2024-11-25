namespace NaoSeiBar.src.data.entities
{
    public interface IFuncionario
    {
        string Cpf { get; set;  }
        string Nome { get; set; }
        DateTime DataNascimento { get; set; }
        Funcao Funcao { get; set; }
        double Salario { get; set; }
        bool Status { get; set; }
        DateTime DataContratacao { get; set; }
        int CargaHorario { get; set; }
        string Telefone { get; set; }
        string Senha { get; set; }

        bool VerificarCpf(string cpf);
    }
}
