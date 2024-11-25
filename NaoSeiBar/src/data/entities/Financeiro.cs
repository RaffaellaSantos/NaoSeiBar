namespace NaoSeiBar.src.data.entities
{
    public class Financeiro : IFuncionario
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Funcao Funcao { get; set; }
        public double Salario { get; set; }
        public bool Status { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CargaHorario { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public Financeiro(string cpf, string nome, DateTime dataNascimento, Funcao funcao, double salario, bool status, DateTime dataContratacao, int cargaHorario, string telefone, string senha)
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Funcao = funcao;
            Salario = salario;
            Status = true;
            DataContratacao = dataContratacao;
            CargaHorario = cargaHorario;
            Telefone = telefone;
            Senha = senha;
        }

        public bool VerificarCpf(string cpf)
        {
            return cpf.Length == 11 && long.TryParse(cpf, out _);
        }
    }
}
